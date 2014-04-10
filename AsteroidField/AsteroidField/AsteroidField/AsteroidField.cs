using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AsteroidField
{
    class AsteroidField
    {
        public float Width { get; private set; }
        public float Height { get; private set; }

        int NbAsteroid;
        public LinkedList<Asteroid> AsteroidList { get; private set; }
        Texture2D[] TextureArray;

        float maxSpeed;
        float minSpeed;

        Random r;

        public AsteroidField(float width, float height, int nbAsteroid, Texture2D[] textureArray)
        {
            r = new Random();

            maxSpeed = 150.0f;
            minSpeed = 50.0f;

            NbAsteroid = nbAsteroid;
            Width = width;
            Height = height;
            AsteroidList = new LinkedList<Asteroid>();
            TextureArray = textureArray;
            populateAsteroidList();
        }

        public LinkedList<Asteroid> GetAsteroidList()
        {
            return AsteroidList;
        }

        public void SetupAsteroid(Asteroid asteroid)
        {
            float X=0.0f;
            float Y=0.0f;

            int side = r.Next(4);
            switch (side)
            {
                case 0:
                    X = -20.0f;
                    Y = Height * (float)r.NextDouble();
                    break;
                case 1:
                    X = Width * (float)r.NextDouble();
                    Y = -20.0f;
                    break;
                case 2:
                    X = Width;
                    Y = Height * (float)r.NextDouble();
                    break;
                case 3:
                    X = Width * (float)r.NextDouble();
                    Y = Height;
                    break;
            }

            Vector2 speed = computeVelocityVector(minSpeed, maxSpeed, side, r);

            asteroid.X = X;
            asteroid.Y = Y;
            asteroid.dX = speed.X;
            asteroid.dY = speed.Y;

            int spriteNumber = r.Next(TextureArray.Length);
            asteroid.Texture = TextureArray[spriteNumber];
        }

        public Vector2 computeVelocityVector(float minSpeed, float maxSpeed, int side, Random r)
        {
            Vector2 result = new Vector2();
            float value = (float) r.NextDouble() * (maxSpeed - minSpeed) + minSpeed;
            float part = (float)r.NextDouble();

            switch (side)
            {
                case 0:
                    result.X = value * part;
                    result.Y = value * (1 - part);
                    break;
                case 1:
                    result.X = value * (1 - part);
                    result.Y = value * part;
                    break;
                case 2:
                    result.X = -value * part;
                    result.Y = value * (1 - part);
                    break;
                case 3:
                    result.X = value * (1 - part);
                    result.Y = -value * part;
                    break;
            }

            return result;
        }

        public float getVelocityValue(float x, float maxSpeed, bool side)
        {
            float value=0.0f;
            float min;
            float max;
            float a = side ? Height : Width;
            float weight = (-2.0f / (a * a) * x * x + 2.0f / a * x);

            if (side)
            {
                if (x < Height / 2)
                {
                    min = -weight * maxSpeed * 2;
                    max = maxSpeed + min;
                }
                else
                {
                    max = weight * maxSpeed * 2;
                    min = maxSpeed - max;
                }
            }
            else
            {
                if (x < Width / 2)
                {
                    min = -weight * maxSpeed * 2;
                    max = maxSpeed + min;
                }
                else
                {
                    max = weight * maxSpeed * 2;
                    min = maxSpeed - max;
                }
            }

            value = (float) r.NextDouble() * (max - min) + min;
            
            return value;
        }

        public void populateAsteroidList()
        {
            if (NbAsteroid > 0)
            {
                for (int i = 0; i < NbAsteroid; ++i)
                {
                    Asteroid asteroid = new Asteroid();
                    SetupAsteroid(asteroid);
                    AsteroidList.AddLast(asteroid);
                }
            }
        }

        public void Update(float dt)
        {
            foreach (Asteroid asteroid in AsteroidList)
            {
                if (asteroid.X < -20.0f || asteroid.Y < -20.0f || asteroid.X > Width || asteroid.Y > Height)
                {
                    SetupAsteroid(asteroid);
                }
                checkCollision(asteroid);
                asteroid.Update(dt);
            }
        }

        public void checkCollision(Asteroid asteroid)
        {
            foreach (Asteroid ast in AsteroidList)
            {
                if (ast == asteroid)
                    continue;
                if (Collide(asteroid, ast))
                {
                    Vector2 temp = asteroid.Velocity;
                    asteroid.Velocity = ast.Velocity;
                    ast.Velocity = temp;
                    while(Collide(asteroid, ast)) 
                        asteroid.Position += asteroid.Velocity*0.001f;
                }
            }
        }

        public bool Collide(Asteroid ast1, Asteroid ast2)
        {
            if (ast2.X + ast2.Size < ast1.X 
                || ast2.X > ast1.X + ast1.Size 
                || ast2.Y + ast2.Size < ast1.Y 
                || ast2.Y > ast1.Y + ast1.Size)
            {
                return false;
            }

            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Asteroid asteroid in AsteroidList)
            {
                spriteBatch.Draw(asteroid.Texture, new Microsoft.Xna.Framework.Rectangle((int)asteroid.X, (int)asteroid.Y, (int)asteroid.Size, (int)asteroid.Size), Color.White);
            }
        }
    }
}

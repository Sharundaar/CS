using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidField
{
    class Asteroid
    {
        private Vector2 position;
        private Vector2 velocity;

        public float Size { get; set; }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        public Texture2D Texture { get; set; }

        public float X
        {
            get
            {
                return position.X;
            }

            set
            {
                position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public float dX
        {
            get
            {
                return velocity.X;
            }
            set
            {
                velocity.X = value;
            }
        }

        public float dY
        {
            get
            {
                return velocity.Y;
            }
            set
            {
                velocity.Y = value;
            }
        }

        public Asteroid()
        {
            Position = new Vector2();
            Velocity = new Vector2();
            Size = 20.0f;
        }

        public Asteroid(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
            Size = 20.0f;
        }

        public void Update(float dt)
        {
            Position += Velocity * dt;
        }
    }
}

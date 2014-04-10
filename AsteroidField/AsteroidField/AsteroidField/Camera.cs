using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidField
{
    class Camera
    {
        private Vector2 position;
        private float width;
        private float height;
        
        private AsteroidField field;

        public float X
        {
            get { return position.X; }
            set { if(value >= 0 && value + width <= field.Width) position.X = value; }
        }
        public float Y
        {
            get { return position.Y; }
            set { if (value >= 0 && value + height <= field.Height) position.Y = value; }
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                if(value.X < 0 || value.Y < 0)
                    position = value;
                else
                    position = Vector2.Zero;
            }
        }

        public Camera(Vector2 position, float width, float height, AsteroidField field)
        {
            this.field = field;
            this.width = width;
            this.height = height;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Asteroid asteroid in field.AsteroidList)
            {
                if (asteroid.X + asteroid.Size >= this.X && asteroid.Y + asteroid.Size >= this.Y && asteroid.X <= this.X + width && asteroid.Y <= this.Y + height)
                {
                    spriteBatch.Draw(asteroid.Texture, new Rectangle((int) (asteroid.X - this.X), (int) (asteroid.Y - this.Y), (int) asteroid.Size, (int) asteroid.Size), Color.White);
                }
            }
        }
    }
}

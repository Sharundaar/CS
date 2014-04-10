using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AsteroidField
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        AsteroidField asteroidField;
        Texture2D background;

        Texture2D Pixel;

        KeyboardState oldKeyboardState;
        KeyboardState currentKeyboardState;

        MouseState oldMouseState;
        MouseState currentMouseState;

        Camera camera;

        bool DisplayCollisionBox;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            DisplayCollisionBox = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            currentKeyboardState = oldKeyboardState = Keyboard.GetState();
            currentMouseState = oldMouseState = Mouse.GetState();

            LinkedList<Texture2D> textureList = new LinkedList<Texture2D>();
            textureList.AddLast(Content.Load<Texture2D>("asteroid-001"));
            textureList.AddLast(Content.Load<Texture2D>("asteroid-002"));
            textureList.AddLast(Content.Load<Texture2D>("planet-001"));
            textureList.AddLast(Content.Load<Texture2D>("planet-002"));
            textureList.AddLast(Content.Load<Texture2D>("planet-003"));
            textureList.AddLast(Content.Load<Texture2D>("planet-004"));
            background = Content.Load<Texture2D>("background");
            Pixel = Content.Load<Texture2D>("pixel");

            asteroidField = new AsteroidField(5000, 2500, 500, textureList.ToArray<Texture2D>());
            IsMouseVisible = true;

            camera = new Camera(Vector2.Zero, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, asteroidField);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (currentKeyboardState.IsKeyDown(Keys.B) && oldKeyboardState.IsKeyUp(Keys.B))
            {
                DisplayCollisionBox = !DisplayCollisionBox;
            }

            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                int dx = currentMouseState.X - oldMouseState.X;
                int dy = currentMouseState.Y - oldMouseState.Y;

                camera.X -= dx;
                camera.Y -= dy;
            }

            asteroidField.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);
            camera.Draw(spriteBatch);
            /*if(DisplayCollisionBox)
                DrawCollisionBox();*/
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawCollisionBox()
        {
            LinkedList<Asteroid> asteroids = asteroidField.GetAsteroidList();

            foreach (Asteroid asteroid in asteroids)
            {
                DrawRectangle(asteroid.Position, asteroid.Size, asteroid.Size);
            }
        }

        protected void DrawLine(Vector2 point1, Vector2 point2)
        {
            float r = Vector2.Distance(point1, point2);
            float theta = (float)Math.Acos((point2.X - point1.X) / r);
            if ((point2.Y - point1.Y) < 0)
            {
                theta = -theta;
            }
            spriteBatch.Draw(Pixel, new Rectangle((int)point1.X, (int)point1.Y, (int)r, 1), null, Color.Red, theta, Vector2.Zero, SpriteEffects.None, 0);
        }

        protected void DrawRectangle(Vector2 point, float width, float height)
        {
            DrawRectangle(point, new Vector2(point.X + width, point.Y + height));
        }

        protected void DrawRectangle(Vector2 point1, Vector2 point2)
        {
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            spriteBatch.Draw(Pixel, new Rectangle((int)point1.X, (int)point1.Y, (int)width, 1), Color.Red);
            spriteBatch.Draw(Pixel, new Rectangle((int)point1.X, (int)point1.Y, 1, (int)height), Color.Red);
            spriteBatch.Draw(Pixel, new Rectangle((int)point1.X, (int)point2.Y, (int)width, 1), Color.Red);
            spriteBatch.Draw(Pixel, new Rectangle((int)point2.X, (int)point1.Y, 1, (int)height), Color.Red);
        }
    }
}

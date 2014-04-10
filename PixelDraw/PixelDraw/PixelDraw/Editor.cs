using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PixelDraw
{
    class Editor : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        ContentManager content;
        public SpriteBatch spriteBatch;
        IntPtr mainForm;

        public Editor(IntPtr mainForm, Point viewSize)
        {
            graphics = new GraphicsDeviceManager(this);
            content = Content;
            Content.RootDirectory = "Content";
            this.mainForm = mainForm;
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(GraphicsPreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle((this.Window.Handle)).VisibleChanged += new EventHandler(GameVisibleChanged);
            graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
            InactiveSleepTime = System.TimeSpan.Zero;
            graphics.PreferredBackBufferWidth = viewSize.X;
            graphics.PreferredBackBufferHeight = viewSize.Y;
            graphics.ApplyChanges();
        
        }

        void GraphicsPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = mainForm;
        }

        private void GameVisibleChanged(object sender, EventArgs e)
        {
            if(System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true) {
                System.Windows.Forms.Control.FromHandle(Window.Handle).Visible = false;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            base.Draw(gameTime);
        }

    }
}

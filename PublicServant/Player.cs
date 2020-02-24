using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//wrapped in the namespace PublicServant.Desktop
//The rest of project now knows about this Player class
namespace PublicServant.Desktop
{
    public class Player
    {
        //declare variable
        //make public for other classes
        public Texture2D servantTexture;
        public Vector2 servantPosition;
        public float servantSpeed;
        private float diagonal;

        public Player()
        {
            servantSpeed = 300f;
            diagonal = servantSpeed * (float)0.75;
        }

        public void PlayerPosition(GraphicsDeviceManager graphics)
        {
            servantPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }

        public void PlayerMovement(
        GameTime gameTime,
        GraphicsDeviceManager graphics
        )
        {
            var kstate = Keyboard.GetState();
            var gameSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //servant movement and speed
            //NorthEast Movement
            if (kstate.IsKeyDown(Keys.W) && kstate.IsKeyDown(Keys.D))
            {
                servantPosition.Y -= diagonal * gameSeconds;
                servantPosition.X += diagonal * gameSeconds;
            }
            //NorthWest Movement
            else if (kstate.IsKeyDown(Keys.W) && kstate.IsKeyDown(Keys.A))
            {
                servantPosition.Y -= diagonal * gameSeconds;
                servantPosition.X -= diagonal * gameSeconds;
            }
            //SouthEast Movement
            else if (kstate.IsKeyDown(Keys.S) && kstate.IsKeyDown(Keys.D))
            {
                servantPosition.Y += diagonal * gameSeconds;
                servantPosition.X += diagonal * gameSeconds;
            }
            //SouthWest Movement
            else if (kstate.IsKeyDown(Keys.S) && kstate.IsKeyDown(Keys.A))
            {
                servantPosition.Y += diagonal * gameSeconds;
                servantPosition.X -= diagonal * gameSeconds;
            }
            //North Movement
            else if (kstate.IsKeyDown(Keys.W))
            {
                servantPosition.Y -= servantSpeed * gameSeconds;
            }
            //East Movement
            else if (kstate.IsKeyDown(Keys.D))
            {
                servantPosition.X += servantSpeed * gameSeconds;
            }
            //South Movement
            else if (kstate.IsKeyDown(Keys.S))
            {
                servantPosition.Y += servantSpeed * gameSeconds;
            }
            //West Movement
            else if (kstate.IsKeyDown(Keys.A))
            {
                servantPosition.X -= servantSpeed * gameSeconds;
            }

            //servant cannot leave window
            if (servantPosition.X > graphics.PreferredBackBufferWidth - servantTexture.Width / 2)
                servantPosition.X = graphics.PreferredBackBufferWidth - servantTexture.Width / 2;
            else if (servantPosition.X < servantTexture.Width / 2)
                servantPosition.X = servantTexture.Width / 2;

            if (servantPosition.Y > graphics.PreferredBackBufferHeight - servantTexture.Height / 2)
                servantPosition.Y = graphics.PreferredBackBufferHeight - servantTexture.Height / 2;
            else if (servantPosition.Y < servantTexture.Height / 2)
                servantPosition.Y = servantTexture.Height / 2;

        }
    }
}

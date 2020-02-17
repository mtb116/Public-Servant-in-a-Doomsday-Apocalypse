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

        public Player()
        {
            servantSpeed = 300f;
        }

        public void PlayerPosition(GraphicsDeviceManager graphics) {
            servantPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        }

        public void PlayerMovement(
        GameTime gameTime,
        GraphicsDeviceManager graphics
        )
        {
            var kstate = Keyboard.GetState();
            //servant movement and speed
            if (kstate.IsKeyDown(Keys.Up))
                servantPosition.Y -= servantSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                servantPosition.Y += servantSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                servantPosition.X -= servantSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                servantPosition.X += servantSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //servant cannot leave window
            if (kstate.IsKeyDown(Keys.Right))
                servantPosition.X += servantSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

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

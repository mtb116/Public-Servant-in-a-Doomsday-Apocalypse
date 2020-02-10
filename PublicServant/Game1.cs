using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PublicServant.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //1) declare new variable to load servant into memory
        Texture2D servantTexture;
        Vector2 servantPosition;
        float servantSpeed;
        //both variables for drawing
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            //searches for content in the content
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
            servantPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            servantSpeed = 300f;

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
            //2) intialize private servant variable
            servantTexture = Content.Load<Texture2D>("servant");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
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
            spriteBatch.Draw(
            servantTexture,
            servantPosition,
            null,
            Color.White,
            0f,
            new Vector2(servantTexture.Width / 2, servantTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}

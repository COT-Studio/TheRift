using Microsoft.Xna.Framework.Graphics;

namespace TheRift
{
    public class GameMain : Game
    {

        #region components

        public Input Input;

        #endregion

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            GameMain game = this;



            #region init components

            Input = new(game, new Keys[] {
                Keys.A,
                Keys.D,
                Keys.W,
                Keys.S,
                Keys.L,
                Keys.K,
                Keys.I,
                Keys.J,
                Keys.Q,
                Keys.E,
                Keys.Enter,
                Keys.Space
            });

            #endregion



            #region add components

            Components.Add(Input);

            #endregion



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
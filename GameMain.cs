using Microsoft.Xna.Framework.Graphics;

namespace TheRift
{
    public class GameMain : Game
    {
        public Vector2 WindowSize = new(800, 480);


        #region components

        public Input Input;
        public Player Player;

        #endregion



        private GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch;

        public Camera Camera;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Camera = new(this, new(), new(1, 1), new(180));

            #region init components

            Input = new(this, new Keys[] {
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

            Player = new(this);

            #endregion



            #region add components

            Components.Add(Input);
            Components.Add(Player);

            #endregion



            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);


            #region load textures

            Player.Textures = new();
            Player.Textures.Add("stay", new Animation(this, "player/stay/", 4, ATMode.SideMirror4, 6));

            #endregion


        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);

            base.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}
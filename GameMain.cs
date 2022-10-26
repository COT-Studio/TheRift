namespace TheRift
{
    public class GameMain : Game
    {
        public Vector2 WindowSize = new(800, 480);


        #region components

        public Input Input;
        public Player Player;

        public EntityList<TestEntity> TestEntities;

        #endregion



        private GraphicsDeviceManager _graphics;
        public SpriteBatch SpriteBatch;

        public SpriteFont testFont;

        public Camera Camera;

        public Ground Ground;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Camera = new(this, new(0, 0, 0), new(1, 1));

            #region init EntityTextures

            Entity.EntityTextures.Add("player", new Dictionary<string, Animation>());
            Entity.EntityTextures.Add("testEntity", new Dictionary<string, Animation>());

            #endregion



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
            TestEntities = new(this);

            #endregion



            #region add components

            Components.Add(Input);
            Components.Add(Player);
            for (int i = 0; i < 100; i++)
            {
                Random random = new();
                TestEntities.Add(new(this, new(random.Next(-2000, 2000), 0, random.Next(-2000, 2000))));
            }

            #endregion



            #region init Ground

            Ground = new(this);

            Ground.SetMapByString(5, 5, "+",
                "+++++" +
                "+++++" +
                "+++++" +
                "+++++" +
                "+++++");

            #endregion



            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            testFont = Content.Load<SpriteFont>("testFont");

            #region load textures



            #region entity

            Entity.EntityTextures["player"].Add("stay", new(this, "player/stay/", 4, ATMode.SideMirror4, 6));

            Entity.EntityTextures["testEntity"].Add("stay", new Animation(this, "testEntity/stay/", 1, ATMode.None, 1));

            #endregion



            #region ground

            Ground.Textures = new Texture2D[]
            {
                Content.Load<Texture2D>("textures/ground/test")
            };

            #endregion



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

            //绘制地面
            SpriteBatch.Begin(transformMatrix: Ground.TransformMatrix);
            //SpriteBatch.Begin();

            Ground.Draw();

            SpriteBatch.End();

            //绘制实体
            SpriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);

            base.Draw(gameTime);

            SpriteBatch.DrawString(testFont, $"Player p: {Player.Position.X},{Player.Position.Y},{Player.Position.Z}\n", new(0, 0), Color.Black);

            SpriteBatch.End();

        }
    }
}
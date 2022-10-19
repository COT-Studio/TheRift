namespace TheRift.Components.Entities
{
    public class Entity : DrawableGameComponent
    {
        protected GameMain game;

        public Vector Position { get; set; }
        public Vector Scale { get; set; }
        public Angle DirectionZ { get; set; }

        public Angle DirectionY { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public float Size { get; init; }
        public float Speed { get; init; }

        public static Dictionary<string, Animation> Textures;
        /// <summary>
        /// 当前正在播放的动画名称
        /// </summary>
        public string Costume { get; set; }

        public Entity(GameMain game) : base(game)
        {
            this.game = game;
        }

        #region properties

        public Transform Transform => new(Position, Scale);

        public Animation currentAnimation => Textures[Costume];

        #endregion



        #region methods

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            var (texture, flip) = currentAnimation.CurrentFrame[game.Camera.DirectionY + DirectionY];
            var (position, scale) = game.Camera.Transform(Transform);

            game.SpriteBatch.Draw(texture, position, null, game.Camera.MaskColor, DirectionZ, new Vector2(texture.Width, texture.Height) / 2, scale, flip, 1f);

            currentAnimation.Update();
        }

        #endregion
    }
}

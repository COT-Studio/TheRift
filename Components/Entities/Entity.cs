namespace TheRift.Components.Entities
{
    public class Entity : DrawableGameComponent
    {
        protected GameMain game;



        #region physics

        /// <summary>
        /// 半径
        /// </summary>
        public static float Size;
        public static float Speed;

        public Vector Position { get; set; }
        public Angle DirectionY { get; set; }

        #endregion



        #region display

        public static Dictionary<string, Animation> Textures;

        public Vector Offset { get; set; }
        public Vector Scale { get; set; }
        public Angle DirectionZ { get; set; }

        /// <summary>
        /// 当前正在播放的动画名称
        /// </summary>
        public string Costume { get; set; }//sc后遗症了属于是

        #endregion



        public Entity(GameMain game) : base(game)
        {
            this.game = game;

            //初始化外观变量
            Offset = new(0, 0, 0);
            Scale = new(1, 1, 1);
            DirectionZ = new(0);

            //初始化物理变量
            Position = new(0, 0, 0);
            DirectionY = new(0);
            Size = 0f;
            Speed = 0f;
        }

        #region properties

        public Transform Transform => new(Position + Offset, Scale);

        public Animation currentAnimation => Textures[Costume];

        #endregion



        #region methods

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            var distance = game.Camera.Position.Z - Position.Z;

            if (3 < distance && distance < 5000)
            {
                var (position, scale) = game.Camera.Transform(Transform);
                var (texture, flip) = currentAnimation.CurrentFrame[game.Camera.DirectionY + 180 - DirectionY];

                game.SpriteBatch.Draw
                (
                    texture,
                    position,
                    null,
                    game.Camera.MaskColor,
                    DirectionZ.Radian,
                    new Vector2(texture.Width, texture.Height) / 2,
                    scale,
                    flip,
                    1f
                );

                currentAnimation.Update();
            }
        }

        #endregion
    }
}

namespace TheRift.Draw
{
    public class Camera : Transform
    {
        private GameMain game;

        private int ZScale = 300;
        public float FOV = 5000;

        public Color MaskColor { get; set; }

        public Camera(GameMain game, Vector position, Vector scale) : base(position, scale)
        {
            this.game = game;
            MaskColor = Color.White;
        }

        #region methods

        public (Vector2, Vector2) Transform(Transform transform)
        {
            var dp = transform.Position - Position;
            return new(
                (Vector2)(dp * Scale / (dp.Z) * ZScale) * new Vector2(1, -1) + game.WindowSize / 2,
                (Vector2)(transform.Scale * Scale / (dp.Z) * ZScale)
            );
        }

        #endregion
    }
}

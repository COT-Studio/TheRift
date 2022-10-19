namespace TheRift.Draw
{
    public class Camera : Transform
    {
        private GameMain game;

        private const int ZScale = 300;
        public Angle DirectionY;
        public Color MaskColor { get; set; }

        public Camera(GameMain game, Vector position, Vector scale, Angle directionY) : base(position, scale)
        {
            this.game = game;
            DirectionY = directionY;
            MaskColor = Color.White;
        }

        #region methods

        public (Vector2, Vector2) Transform(Transform transform) => 
            new(
                (Vector2)((transform.Position - Position) * Scale / (Position.Z - transform.Position.Z) * ZScale) * new Vector2(1, -1) + game.WindowSize / 2,
                (Vector2)(transform.Scale * Scale / (Position.Z - transform.Position.Z) * ZScale)
            );

        #endregion
    }
}

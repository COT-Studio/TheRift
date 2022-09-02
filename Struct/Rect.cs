namespace TheRift.Struct
{
    public struct Rect
    {
        /* 为什么不叫Rectangle：
         * XNA有个类叫Rectangle；
         * 把矩形叫Rect是我个人的习惯；
         * 相比Vector这些单词，Rectangle全拼太长
         */

        public Vector Position;
        public Vector Size;

        public Rect(Vector position, Vector size)
        {
            Position = position;
            Size = size;
        }



        #region properties

        public float Area => Size.X * Size.Y;
        public float Left => Position.X - Size.X;
        public float Top => Position.Y + Size.Y;
        public float Right => Position.X + Size.X;
        public float Bottom => Position.Y - Size.Y;
        public float Width { get => 2 * Size.X; set => Size.X = 0.5f * value; }
        public float Height { get => 2 * Size.Y; set => Size.Y = 0.5f * value; }

        #endregion



        #region methods

        public bool Contain(Rect rect) =>
            Left >= rect.Left &&
            Right >= rect.Right &&
            Bottom >= rect.Bottom &&
            Top >= rect.Top;

        public bool Hit(Rect rect) =>
            MathF.Abs(Position.X - rect.Position.X) < MathF.Abs(Size.X - rect.Size.X) &&
            MathF.Abs(Position.Y - rect.Position.Y) < MathF.Abs(Size.Y - rect.Size.Y);



        public override bool Equals(object obj)
        {
            return obj is Rect rect &&
                   EqualityComparer<Vector>.Default.Equals(Position, rect.Position) &&
                   EqualityComparer<Vector>.Default.Equals(Size, rect.Size);
        }

        #endregion

    }
}

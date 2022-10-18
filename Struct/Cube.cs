namespace TheRift.Struct
{
    public struct Cube
    {

        public Vector Position;
        public Vector Size;

        public Cube(Vector position, Vector size)
        {
            Position = position;
            Size = size;
        }



        #region properties

        public float Volume => Size.X * Size.Y * Size.Z;

        public float X { get => Position.X; set => Position.X = value; }
        public float Y { get => Position.Y; set => Position.Y = value; }

        #endregion



        #region methods

        public bool Hit(Cube rect) => MathF.Abs(Position.X - rect.Position.X) <= MathF.Abs(Size.X - rect.Size.X) &&
            MathF.Abs(Position.Y - rect.Position.Y) <= MathF.Abs(Size.Y - rect.Size.Y) &&
            MathF.Abs(Position.Z - rect.Position.Z) <= MathF.Abs(Size.Z - rect.Size.Z);

        #endregion

    }
}

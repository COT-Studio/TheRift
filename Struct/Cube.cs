namespace TheRift.Struct
{
    public struct Cube
    {

        public Vector Position { get; set; }
        public Vector Size { get; set; }

        public Cube(Vector position, Vector size)
        {
            Position = position;
            Size = size;
        }



        #region properties

        public float Volume => Size.X * Size.Y * Size.Z;

        #endregion



        #region methods

        public bool Hit(Cube rect) => MathF.Abs(Position.X - rect.Position.X) <= MathF.Abs(Size.X - rect.Size.X) &&
            MathF.Abs(Position.Y - rect.Position.Y) <= MathF.Abs(Size.Y - rect.Size.Y) &&
            MathF.Abs(Position.Z - rect.Position.Z) <= MathF.Abs(Size.Z - rect.Size.Z);

        #endregion

    }
}

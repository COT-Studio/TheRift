
namespace TheRift.Struct
{
    public struct Vector
    {
        public float X;
        public float Y;
        
        public Vector(float x = 0f, float y = 0f)
        {
            this.X = x;
            this.Y = y;
        }

        #region operators

        public static Vector operator +(Vector v1, Vector v2) => new(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector operator -(Vector v1, Vector v2) => new(v1.X - v2.X, v1.Y - v2.Y);
        public static Vector operator *(Vector v, float n) => new(v.X * n, v.Y * n);
        public static Vector operator *(Vector v1, Vector v2) => new(v1.X * v2.X, v1.Y * v2.Y);
        public static Vector operator /(Vector v, float n) => new(v.X / n, v.Y / n);
        public static Vector operator /(Vector v1, Vector v2) => new(v1.X / v2.X, v1.Y / v2.Y);

        #endregion



        #region properties

        public float LengthSquare => X * X + Y * Y;
        public float Length => MathF.Sqrt(X * X + Y * Y);
        public Vector Normalized => this / Length;
        public Vector Floor => new(MathF.Floor(X), MathF.Floor(Y));
        public Vector Round => new(MathF.Round(X), MathF.Round(Y));
        public Vector Celling => new(MathF.Ceiling(X), MathF.Ceiling(Y));
        public Angle Direction => new(MathF.Atan2(Y, X));
        #endregion



        #region methods

        public Vector Rotate(Angle a) => new((float)(X * MathF.Cos(a) + Y * MathF.Sin(a)), (float)(Y * Math.Cos(a) - X * MathF.Sin(a)));



        public override bool Equals(object obj)
        {
            return obj is Vector vector &&
                   X == vector.X &&
                   Y == vector.Y;
        }

        #endregion

    }
}

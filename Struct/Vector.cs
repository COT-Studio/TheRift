namespace TheRift.Struct
{
    public struct Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static explicit operator Vector2(Vector v) => new(v.X, v.Y);

        public Vector(float x = 0f, float y = 0f, float z = 0f)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region operators

        public static Vector operator +(Vector v1, Vector v2) => new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector operator -(Vector v1, Vector v2) => new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        public static Vector operator -(Vector v) => new(-v.X, -v.Y, -v.Z);
        public static Vector operator *(Vector v, float n) => new(v.X * n, v.Y * n, v.Z * n);
        public static Vector operator *(Vector v1, Vector v2) => new(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        public static Vector operator /(Vector v, float n) => new(v.X / n, v.Y / n, v.Z / n);
        public static Vector operator /(Vector v1, Vector v2) => new(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);

        #endregion



        #region properties

        public float LengthSquare => X * X + Y * Y + Z * Z;
        public float Length => MathF.Sqrt(LengthSquare);
        public Vector Normalized => this / Length;
        public Vector Floor => new(MathF.Floor(X), MathF.Floor(Y), MathF.Floor(Z));
        public Vector Round => new(MathF.Round(X), MathF.Round(Y), MathF.Round(Z));
        public Vector Celling => new(MathF.Ceiling(X), MathF.Ceiling(Y), MathF.Ceiling(Z));
        public Angle DirectionX => new(MathF.Atan2(Z, Y), true);
        public Angle DirectionY => new(MathF.Atan2(X, Z), true);
        public Angle DirectionZ => new(MathF.Atan2(Y, X), true);
        #endregion



        #region methods

        /// <summary>
        /// 从屏幕外看来，正角 = 后空翻，负角 = 前滚翻（奇妙比喻）
        /// </summary>
        public Vector RotateX(Angle a) => new(X, (float)(Y * MathF.Cos(a.Radian) + Z * MathF.Sin(a.Radian)), (float)(Z * Math.Cos(a.Radian) - Y * MathF.Sin(a.Radian)));
        /// <summary>
        /// 从屏幕外看来，正角 = 北顺南逆，负角 = 北逆南顺
        /// </summary>
        public Vector RotateY(Angle a) => new((float)(Z * MathF.Cos(a.Radian) + X * MathF.Sin(a.Radian)), Y, (float)(X * Math.Cos(a.Radian) - Z * MathF.Sin(a.Radian)));
        /// <summary>
        /// 从屏幕外看来即为在XY平面上旋转
        /// </summary>
        public Vector RotateZ(Angle a) => new((float)(X * MathF.Cos(a.Radian) + Y * MathF.Sin(a.Radian)), (float)(Y * Math.Cos(a.Radian) - X * MathF.Sin(a.Radian)), Z);

        #endregion

    }
}

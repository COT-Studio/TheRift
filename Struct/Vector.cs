﻿namespace TheRift.Struct
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
        public Angle DirectionX => new(MathF.Atan2(Z, Y));
        public Angle DirectionY => new(MathF.Atan2(X, Z));
        public Angle DirectionZ => new(MathF.Atan2(Y, X));
        #endregion



        #region methods

        /// <summary>
        /// 从屏幕外看来，顺时针 = 后空翻，逆时针 = 前滚翻（奇妙比喻）
        /// </summary>
        public Vector RotateX(Angle a) => new((float)(Y * MathF.Cos(a) + Z * MathF.Sin(a)), (float)(Z * Math.Cos(a) - Y * MathF.Sin(a)));
        /// <summary>
        /// 从屏幕外看来，顺时针 = 北顺南逆，逆时针 = 北逆南顺
        /// </summary>
        public Vector RotateY(Angle a) => new((float)(Z * MathF.Cos(a) + X * MathF.Sin(a)), (float)(X * Math.Cos(a) - Z * MathF.Sin(a)));
        /// <summary>
        /// 从屏幕外看来即为在XY平面上旋转
        /// </summary>
        public Vector RotateZ(Angle a) => new((float)(X * MathF.Cos(a) + Y * MathF.Sin(a)), (float)(Y * Math.Cos(a) - X * MathF.Sin(a)));

        #endregion

    }
}

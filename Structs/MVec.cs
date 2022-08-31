
namespace TheRift.Structs
{
    public struct MVec
    {
        public float x;
        public float y;
        
        public MVec(float x = 0f, float y = 0f)
        {
            this.x = x;
            this.y = y;
        }

        #region operators

        public static MVec operator +(MVec v1, MVec v2) => new(v1.x + v2.x, v1.y + v2.y);
        public static MVec operator -(MVec v1, MVec v2) => new(v1.x - v2.x, v1.y - v2.y);
        public static MVec operator *(MVec v, float n) => new(v.x * n, v.y * n);
        public static MVec operator *(MVec v1, MVec v2) => new(v1.x * v2.x, v1.y * v2.y);
        public static MVec operator /(MVec v, float n) => new(v.x / n, v.y / n);
        public static MVec operator /(MVec v1, MVec v2) => new(v1.x / v2.x, v1.y / v2.y);

        #endregion



        #region properties

        public float LengthSquare => x * x + y * y;
        public float Length => MathF.Sqrt(x * x + y * y);
        public MVec Normalized => this / Length;
        public MVec Floor => new(MathF.Floor(x), MathF.Floor(y));
        public MVec Round => new(MathF.Round(x), MathF.Round(y));
        public MVec Celling => new(MathF.Ceiling(x), MathF.Ceiling(y));
        public Angle Direction => new(MathF.Atan2(y, x));
        #endregion



        #region methods

        public MVec Rotate(Angle a) => new((float)(x * MathF.Cos(a) + y * MathF.Sin(a)), (float)(y * Math.Cos(a) - x * MathF.Sin(a)));

        #endregion

    }
}



namespace TheRift.Struct
{
    public struct Angle
    {
        //_size使用角度制表示角的大小
        private float _size;

        public static implicit operator Angle(float v) => new(v);
        public static implicit operator float(Angle v) => v.Degree;

        public Angle(float degree = 0) => _size = degree;



        #region properties

        public float Degree { get => (_size + 180) % 360 - 180; set => _size = (value + 180) % 360 - 180; }
        public float Radian { get => Degree * MathF.PI / 180; set => Degree = value * 180 / MathF.PI; }

        public Angle Abs => new(MathF.Abs(Degree));

        #endregion



        #region operators

        public static Angle operator +(Angle a, Angle b) => new(a.Degree + b.Degree);
        public static Angle operator -(Angle a, Angle b) => new(a.Degree - b.Degree);
        public static Angle operator *(Angle a, float n) => new(a.Degree * n);
        public static Angle operator /(Angle a, float n) => new(a.Degree / n);

        public static bool operator ==(Angle a, Angle b) => a.Degree == b.Degree;
        public static bool operator !=(Angle a, Angle b) => !(a == b);

        #endregion



        #region methods

        public Angle Round(int division = 4) => new(MathF.Round(Degree / division) * division);



        public override bool Equals(object obj)
        {
            return obj is Angle angle && Degree == angle.Degree;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Degree);
        }

        #endregion

    }
}

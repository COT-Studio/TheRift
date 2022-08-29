using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRift.Structs
{
    public struct Angle
    {

        public float Degree { get => (_size + 180) % 360 - 180; set => _size = (value + 180) % 360 - 180; }
        public float Radian{ get => Degree * MathF.PI / 180; set => Degree = value * 180 / MathF.PI; }
        //_size使用角度制表示角的大小
        private float _size;

        public Angle(float degree = 0) => _size = degree;

        #region operators
        public static implicit operator Angle(float v) => new(v);
        public static implicit operator float(Angle v) => v.Degree;
        public static Angle operator +(Angle a, Angle b) => new(a.Degree + b.Degree);
        public static Angle operator -(Angle a, Angle b) => new(a.Degree - b.Degree);
        public static Angle operator *(Angle a, float n) => new(a.Degree * n);
        public static Angle operator /(Angle a, float n) => new(a.Degree / n);

        #endregion



        #region properties

        public Angle Abs => new(MathF.Abs(Degree));

        #endregion

    }
}

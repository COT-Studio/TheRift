namespace TheRift.Draw
{
    public class Transform
    {
        public Vector Position { get; set; }
        public Vector Scale { get; set; }

        public Transform(Vector position, Vector scale)
        {
            Position = position;
            Scale = scale;
        }
    }
}

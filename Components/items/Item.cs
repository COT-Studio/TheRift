namespace TheRift.Components.items
{
    abstract public class Item
    {
        public readonly string ID;
        public readonly int MaxDuration;

        public int Duration { get; set; }

        public Item()
        {
            Duration = MaxDuration;
        }

        public Item(int duration)
        {
            Duration = duration;
        }

        #region properties

        /// <summary>
        /// 剩余耐久比例
        /// </summary>
        public float DurationRatio => Duration / MaxDuration;
        public abstract string Name { get; }
        public abstract int Damage { get; }

        #endregion
    }
}

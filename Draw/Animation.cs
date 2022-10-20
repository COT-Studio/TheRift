namespace TheRift.Draw
{
    public class Animation
    {
        public AngularTexture[] Frames { get; init; }
        public int Delay { get; init; }

        private int timer;



        public Animation(AngularTexture[] frames, int delay)
        {
            Frames = frames;
            Delay = delay;
            init();
        }

        public Animation(GameMain game, string url, int frameCount, ATMode mode, int delay)
        {
            var frames = new AngularTexture[frameCount];

            for (int i = 0; i < frameCount; i++)
            {
                frames[i] = new(game, mode, $"textures/{url}", i);
            }

            Frames = frames;
            Delay = delay;
            init();
        }



        #region properties

        public AngularTexture CurrentFrame => Frames[(int)MathF.Floor(timer / Delay) % Frames.Length];

        public int CyclingTimes => (int)MathF.Floor(timer / Delay / Frames.Length);

        #endregion



        #region methods

        public void init() => timer = 0;

        public void Update() => timer++;

        #endregion
    }
}

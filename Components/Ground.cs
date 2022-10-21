namespace TheRift.Components
{
    public class Ground
    {
        private GameMain game;

        //声明一下，这个矩阵是我在网上抄来的，我不懂矩阵
        public Matrix TransformMatrix =
            new(
                1f, 0f, 0f, 0f,
                0f, 0f, -1f, 0f,
                0f, 1f, 0f, 0f,
                0f, 0f, 0f, 1f
            );
        public Texture2D[] Textures;

        public int[,] Map;

        public Ground(GameMain game)
        {
            this.game = game;
        }

        #region methods

        public void SetMapByString(string map, int width, int height)
        {
            Map = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Map[x, y] = map[x + y * width];
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Map.Length; y++)
            {

            }
        }

        #endregion
    }
}

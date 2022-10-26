using System.Reflection.Metadata.Ecma335;

namespace TheRift.Components
{
    public class Ground
    {
        private GameMain game;

        //求一个懂矩阵的大佬帮我写一个能让图像绕x轴旋转90°再向下平移以绘制地面的矩阵！！！
        public readonly Matrix TransformMatrix = Matrix.CreateRotationX(0.01f);
        /*public Matrix TransformMatrix =
            new(
                1f, 0f, 0f, 0f,
                0f, 1f, 0.01f, 0f,
                0f, -0.01f, 1f, 0f,
                0f, 300f, 0f, 1f
            );
        */

        public Texture2D[] Textures;

        public int[,] Map;

        private readonly Vector2 scale = new(1);

        private const int size = 200;

        public Ground(GameMain game)
        {
            this.game = game;
        }

        #region methods

        public void SetMapByString(int width, int height, string tileNames, string map)
        {
            Map = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Map[x, y] = tileNames.IndexOf(map[x + y * width]);
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                for (int x = 0; x < Map.GetLength(0); x++)
                {
                    Vector2 position = (new Vector2(x, y) * 200 - new Vector2(game.Camera.Position.X, game.Camera.Position.Z))
                        * new Vector2(1, -1) + game.WindowSize / 2;

                    game.SpriteBatch.Draw
                    (
                        Textures[Map[x, y]],
                        position,
                        null,
                        game.Camera.MaskColor,
                        0f,
                        new Vector2(),
                        scale,
                        SpriteEffects.None,
                        0f
                    );
                }
            }
        }

        #endregion
    }
}

namespace TheRift.Draw
{
/// <summary>
 /// AngularTextureMode
 /// </summary>
    public enum ATMode
    {
        /// <summary>
        /// 所有方向都采用同一张贴图
        /// </summary>
        None,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有一张贴图
        /// </summary>
        Mirror2,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有两张贴图
        /// </summary>
        Mirror4,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有三张贴图
        /// </summary>
        Mirror6,
        /// <summary>
        /// 用于前、后两面不成轴对称，但两侧相互对称的实体
        /// 前后各有一张贴图（不会翻转），两侧共用一张贴图
        /// </summary>
        SideMirror4
    }

    public class AngularTexture
    {
        private Texture2D[] textures;

        private ATMode mode;

        public AngularTexture(Texture2D[] textures, ATMode mode)
        {
            this.textures = textures;
            this.mode = mode;
        }

        public AngularTexture(GameMain game, ATMode mode, string url, int frame)
        {
            this.mode = mode;

            int TextureCount;
            //规定各种ATMode分别需要加载多少张贴图
            switch (mode)
            {
                case ATMode.None:
                    TextureCount = 1;
                    break;
                case ATMode.Mirror2:
                    TextureCount = 1;
                    break;
                case ATMode.Mirror4:
                    TextureCount = 2;
                    break;
                case ATMode.Mirror6:
                    TextureCount = 3;
                    break;
                case ATMode.SideMirror4:
                    TextureCount = 3;
                    break;
                default:
                    TextureCount = 1;
                    break;
            }

            textures = new Texture2D[TextureCount];

            for (int i = 0; i < TextureCount; i++)
            {
                textures[i] = game.Content.Load<Texture2D>($"{url}{i}-{frame}");
            }
        }

        #region methods

        public (Texture2D, SpriteEffects) this[Angle a]
        {
            get
            {
                if (mode == ATMode.None)
                {
                    return (textures[0], SpriteEffects.None);
                }
                else
                {
                    var flip = a > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                    if (mode == ATMode.Mirror2)
                    {
                        return (textures[0], flip);
                    }
                    else if (mode == ATMode.Mirror4)
                    {
                        return (textures[(int)MathF.Abs(((a - 45).Round(4) / 90) % 2)], flip);
                    }
                    else if (mode == ATMode.Mirror6)
                    {
                        return (textures[(int)MathF.Abs(((a - 30).Round(6) / 60) % 3)], flip);
                    }
                    else if (mode == ATMode.SideMirror4)
                    {
                        int index = (int)MathF.Abs(a.Round(4) / 90 % 3);
                        return (textures[index], index == 0 || index == textures.Length ? SpriteEffects.None : flip);
                    }
                    else
                    {
                        return (textures[0], SpriteEffects.None);
                    }
                }
            }
        }

        #endregion
    }
}

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
        none,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有一张贴图
        /// </summary>
        mirror2,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有两张贴图
        /// </summary>
        mirror4,
        /// <summary>
        /// 用于镜面对称（两侧对称）的实体
        /// 每一侧有三张贴图
        /// </summary>
        mirror6
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

        public AngularTexture(GameMain game, ATMode mode, string url)
        {
            int TextureCount;
            //规定各种ATMode分别需要加载多少张贴图
            switch (mode)
            {
                case ATMode.none:
                    TextureCount = 1;
                    break;
                case ATMode.mirror2:
                    TextureCount = 1;
                    break;
                case ATMode.mirror4:
                    TextureCount = 2;
                    break;
                case ATMode.mirror6:
                    TextureCount = 3;
                    break;
                default:
                    TextureCount = 1;
                    break;
            }

            textures = new Texture2D[TextureCount];

            for (int i = 0; i < TextureCount; i++)
            {
                textures[i] = game.Content.Load<Texture2D>($"{url}{i}");
            }
        }

        #region methods

        public (Texture2D, SpriteEffects) this[Angle a]
        {
            get
            {
                if (mode == ATMode.none)
                {
                    return (textures[0], SpriteEffects.None);
                }
                else {
                    var flip = a > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                    if (mode == ATMode.mirror2)
                    {
                        return (textures[0], flip);
                    }
                    else if (mode == ATMode.mirror4)
                    {
                        return (textures[(int)(a - 45).Round(4) % 2], flip);
                    }
                    else if (mode == ATMode.mirror6)
                    {
                        return (textures[(int)(a - 30).Round(6) % 3], flip);
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

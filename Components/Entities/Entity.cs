﻿namespace TheRift.Components.Entities
{
    public enum EntityEvents
    {
        Interact,
        Attack,
        Give
    }

    public abstract class Entity : DrawableGameComponent
    {
        protected GameMain game;

        /// <summary>
        /// 存储所有实体所用到的贴图
        /// </summary>
        public static readonly Dictionary<string, Dictionary<string, Animation>> EntityTextures = new();



        #region physics

        /// <summary>
        /// 半径
        /// </summary>
        public float Size { get; init; }
        public float Speed { get; init; }
        public float Range { get; init; }

        public Vector Position { get; set; }
        public Angle DirectionY { get; set; }

        #endregion



        #region display

        /// <summary>
        /// 存储当前实体所用到的贴图
        /// </summary>
        protected Dictionary<string, Animation> Textures { get; set; }

        public Vector Offset { get; set; }
        public Vector Scale { get; set; }
        public Angle DirectionZ { get; set; }

        /// <summary>
        /// 当前正在播放的动画名称
        /// </summary>
        public string Costume { get; set; }//sc后遗症了属于是

        #endregion



        #region game logic

        public Behavior Behavior { get; protected set; }

        public Inventory Inventory { get; protected set; }

        #endregion



        public Entity(GameMain game) : base(game)
        {
            this.game = game;

            //初始化外观变量
            Offset = new(0, 0, 0);
            Scale = new(1, 1, 1);
            DirectionZ = new(0);

            //初始化物理变量
            Position = new(0, 0, 0);
            DirectionY = new(0);
            Size = 0f;
            Speed = 0f;

            //初始化游戏逻辑变量
            Behavior = "init";
            Inventory = new();

        }



        #region properties

        public Transform Transform => new(Position + Offset, Scale);

        public Animation CurrentAnimation => Textures[Costume];

        public Item HeadSlotItem => Inventory.HeadSlot;
        public Item BodySlotItem => Inventory.BodySlot;
        public Item HandSlotItem => Inventory.HandSlot;

        #endregion



        #region methods

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Behavior.Do();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            var distance = Position.Z - game.Camera.Position.Z;

            if (0 < distance && distance < game.Camera.FOV)
            {
                var (position, scale) = game.Camera.Transform(Transform);
                var (texture, flip) = CurrentAnimation.CurrentFrame[180 + DirectionY];

                game.SpriteBatch.Draw
                (
                    texture,
                    position,
                    null,
                    game.Camera.MaskColor,
                    DirectionZ.Radian,
                    new Vector2(texture.Width, texture.Height) / 2,
                    scale,
                    flip,
                    distance / game.Camera.FOV
                );

                CurrentAnimation.Update();

            }
        }

        public virtual void Event(Entity subject, EntityEvents action)
        {

        }

        public virtual bool CheckEvent(Entity subject, EntityEvents action) => true;

        #endregion

    }
}

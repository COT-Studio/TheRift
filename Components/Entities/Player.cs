namespace TheRift.Components.Entities
{
    public class Player : Entity
    {
        public Player(GameMain game) : base(game)
        {
            Size = 80f;
            Speed = 5f;
            Range = 80f;

            Textures = EntityTextures["player"];
            Costume = "stay";

            TrackOffset = new(0, 50, -400);

            Behavior = delegate ()
            {
                var movement = new Vector();
                //检测玩家的移动操作
                if (game.Input.KeyDown(KeyName.Down))
                {
                    movement += new Vector(0, 0, -Speed);
                }
                if (game.Input.KeyDown(KeyName.Up))
                {
                    movement += new Vector(0, 0, Speed);
                }
                if (game.Input.KeyDown(KeyName.Right))
                {
                    movement += new Vector(Speed, 0, 0);
                }
                if (game.Input.KeyDown(KeyName.Left))
                {
                    movement += new Vector(-Speed, 0, 0);
                }
                //移动
                if (movement.LengthSquare > 0)
                {
                    Position += movement;
                    DirectionY = movement.DirectionY;
                }

                //使摄像机跟随
                Track();
            };
        }



        #region methods



        #endregion

    }
}

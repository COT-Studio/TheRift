namespace TheRift.Components.Entities
{
    public class Player : Entity
    {
        public Player(GameMain game) : base(game)
        {
            Size = 80f;
            Speed = 5f;

            Textures = EntityTextures["player"];

            Costume = "stay";
        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            var movement = new Vector();

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

            if (movement.LengthSquare > 0)
            {
                Position += movement;
                DirectionY = movement.DirectionY;
            }

            game.Camera.Position += (Position + new Vector(0, 50, -400) - game.Camera.Position) / 10;
        }
    }
}

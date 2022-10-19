namespace TheRift.Components.Entities
{
    public class Player : Entity
    {
        public Player(GameMain game) : base(game)
        {
            Size = 80f;
            Speed = 5f;

            Scale = new(1, 1, 1);
            Costume = "stay";
            game.Camera.Position = Position + new Vector(0, 0, 300);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (game.Input.KeyDown(KeyName.Down))
            {
                Position += new Vector(0, 0, Speed);
            }
            if (game.Input.KeyDown(KeyName.Up))
            {
                Position += new Vector(0, 0, -Speed);
            }
            if (game.Input.KeyDown(KeyName.Right))
            {
                Position += new Vector(Speed, 0, 0);
            }
            if (game.Input.KeyDown(KeyName.Left))
            {
                Position += new Vector(-Speed, 0, 0);
            }
        }
    }
}

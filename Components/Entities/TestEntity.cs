namespace TheRift.Components.Entities
{
    public class TestEntity : Entity
    {
        public TestEntity(GameMain game, Vector position) : base(game)
        {
            Position = position;

            Textures = EntityTextures["testEntity"];

            Costume = "stay";
        }
    }
}

namespace TheRift.Components.Entities.Behaviors
{
    public delegate void behaviorDelegate();

    public class Behavior
    {
        protected behaviorDelegate behavior;

        public Behavior(behaviorDelegate behavior)
        {
            this.behavior = behavior;
        }

        public void Do() => behavior();
    }
}

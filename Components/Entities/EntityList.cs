using System.Collections;

namespace TheRift.Components.Entities
{
    public class EntityList<T> : ICollection<T> where T : Entity
    {
        private readonly GameMain game;
        private readonly GameComponentCollection components;
        public List<T> Items { get; set; }

        public EntityList(GameMain game)
        {
            this.game = game;
            this.components = game.Components;

            Items = new List<T>();
        }



        #region properties

        public int Count => ((ICollection<T>)Items).Count;

        public bool IsReadOnly => ((ICollection<T>)Items).IsReadOnly;

        #endregion



        #region methods

        public void Add(T item)
        {
            ((ICollection<T>)Items).Add(item);
            components.Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)Items).Clear();
            components.Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)Items).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)Items).Remove(item);
            components.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }

        #endregion
    }
}

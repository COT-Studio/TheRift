using System.Collections;

namespace TheRift.Components
{
    public class Inventory : IList<Item>
    {
        private List<Item> items;

        public Item HeadSlot { get; set; }
        public Item BodySlot { get; set; }
        public Item HandSlot { get; set; }



        #region properties

        public int Count => ((ICollection<Item>)items).Count;

        public bool IsReadOnly => ((ICollection<Item>)items).IsReadOnly;

        #endregion



        #region methods

        public Item this[int index] { get => ((IList<Item>)items)[index]; set => ((IList<Item>)items)[index] = value; }

        public void Add(Item item)
        {
            ((ICollection<Item>)items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Item>)items).Clear();
        }

        public bool Contains(Item item)
        {
            return ((ICollection<Item>)items).Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            ((ICollection<Item>)items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)items).GetEnumerator();
        }

        public int IndexOf(Item item)
        {
            return ((IList<Item>)items).IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            ((IList<Item>)items).Insert(index, item);
        }

        public bool Remove(Item item)
        {
            return ((ICollection<Item>)items).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Item>)items).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

        #endregion

    }
}

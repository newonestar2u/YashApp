using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SalesApp.Model.Extensions
{
    public class ObservableList<T>: INotifyCollectionChanged, IList<T>
    {
        private IList<T> list;

        public ObservableList()
        {
            list = new List<T>();
        }

        public ObservableList(IList<T> list)
        {
            this.list = list;
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            list.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        public void Clear()
        {
            list.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array,arrayIndex);
        }

        public bool Remove(T item)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            return list.Remove(item);
        }

        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return list.IsReadOnly; } }
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        public T this[int index]
        {
            get { return list[index]; }
            set
            {
                list[index] = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
            }
        }
    }
}

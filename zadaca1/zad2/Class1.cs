using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        int size = 0;

        public GenericList()
        {
            _internalStorage = new X[10];

        }
        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];

        }


        public int Count
        {
            get
            {
                return size;
            }
        }


        public void Add(X item)
        {

            if (size >= _internalStorage.Length)
            {
                Array.Copy(_internalStorage, _internalStorage, _internalStorage.Length * 2);
            }

            _internalStorage[size] = item;
            size++;

        }

        public void Clear()
        {
            X[] temp = new X[_internalStorage.Length];
            Array.Copy(temp, _internalStorage, _internalStorage.Length);
            size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index < _internalStorage.Length && index >= 0)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            int index = -1;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;

        }

        public bool Remove(X item)
        {
            int index = -1;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= _internalStorage.Length || index < 0)
            {
                return false;
            }
            _internalStorage[index] = default(X);
            for (int i = index; i < _internalStorage.Length; i++)
            {
                if (i == _internalStorage.Length - 1)
                {
                    _internalStorage[i] = default(X);
                }
                else
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
            }
            size--;
            return true;

        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private IGenericList<X> collection;
        int position = -1;

        public GenericListEnumerator(IGenericList<X> collection)
        {
            this.collection = collection;
        }

        public bool MoveNext()
        {
            position++;
            return (position < collection.Count);
        }


        public X Current
        {
            get
            {
                return collection.GetElement(position);
            }
        }
        

        object IEnumerator.Current
        {
            get{ return Current; }
        }


        public void Dispose()
        {
        }


        public void Reset()
        {
        }

    }
}

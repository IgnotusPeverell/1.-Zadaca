using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        int size=0;

        public IntegerList()
        {
            _internalStorage = new int[4];
            
        }
        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            
        }


        public int Count
        {
            get
            {
                return size;
            }
        }

      
        public void Add(int item)
        {

            if (size>=_internalStorage.Length)
            {
                Array.Copy(_internalStorage, _internalStorage, _internalStorage.Length * 2);
            }

            _internalStorage[size] = item;
            size++;

        }

        public void Clear()
        {
            int[] temp = new int[_internalStorage.Length];
            Array.Copy(temp, _internalStorage, _internalStorage.Length);
            size = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index) 
        {
            if(index < _internalStorage.Length && index >= 0)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            int index = -1;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    index = i;
                    break;
                }
            }
            return index;

        }

        public bool Remove(int item)
        {
            int index=-1;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item)
                {
                    index = i;
                    break;
                }
            }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if(index >= _internalStorage.Length || index < 0)
            {
                return false;
            }
            _internalStorage[index] = 0;
            for(int i=index; i < _internalStorage.Length; i++)
            {
                if (i == _internalStorage.Length - 1)
                {
                    _internalStorage[i] = 0;
                }
                else
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
            }
            size--;
            return true;

        }
    }
}

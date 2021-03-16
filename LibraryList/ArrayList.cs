using System;

namespace LibraryList
{
    public class ArrayList
    {
        public int Lenght { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Lenght = 0;
            _array = new int[10];
        }
        public ArrayList(int el)
        {
            Lenght = 1;
            _array = new int[10];
            _array[0] = el;
        }

        public ArrayList(int[] initArray)
        {
            Lenght = 0;
            _array = new int[initArray.Length];
            for (int i = 0; i < initArray.Length; i++)
            {
                AddInLast(initArray[i]);
            }
        }

        public void AddInLast(int value)
        {
            if (Lenght >= _array.Length)
            {
                ReSize(true);
            }
            _array[Lenght] = value;

            Lenght++;
        }

        public void AddInStart(int value)
        {

            if (Lenght == _array.Length)
            {
                ReSize(true);
            }

            for (int i = Lenght; i >= 0; --i)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = value;

            Lenght++;
        }

        public void Insert(int index, int value)
        {
            if (index < Lenght && index >= 0)
            {
                if (Lenght == _array.Length)
                {
                    ReSize(true);
                }

                for (int i = Lenght; i >= index; i--)
                {
                    _array[i + 1] = _array[i];
                }

                _array[index] = value;
                Lenght++;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public int IndexAccess(int index)
        {
            if (index < Lenght && index >= 0)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
        }

        public void RemoveLast()
        {
            if (Lenght < _array.Length / 2)
            {
                ReSize(false);
            }

            Lenght--;

        }

        public void RemoveFirst()
        {
            if (Lenght < _array.Length / 2)
            {
                ReSize(false);
            }

            for (int i = 0; i < Lenght; i++)
            {
                _array[i] = _array[i + 1];
            }
            Lenght--;
        }

        public void RemoveAt(int index)
        {
            if (Lenght <= _array.Length / 2)
            {
                ReSize(false);
            }

            for (int i = index; i < Lenght; i++)
            {
                _array[i] = _array[i + 1];

            }

            Lenght--;
        }

        public void RemoveNElementsFromEnd(int nElelements)
        {

            Lenght -= Lenght >= nElelements ? nElelements : Lenght;

            if (Lenght <= _array.Length / 2)
            {
                ReSize(false);
            }
        }

        public void RemoveNElementsAt(int index, int nElelements)
        {

            for (int i = 0; i < Lenght; i++)
            {
                _array[i] = _array[i + 1];
            }
            Lenght--;

        }

        public void RemoveNElementsFromStart(int nElelements)
        {
            Lenght -= Lenght >= nElelements ? nElelements : Lenght;

            for (int i = 0; i < Lenght; i++)
            {
                _array[i] = _array[i + nElelements];
            }

            if (Lenght != 0 && Lenght <= _array.Length / 2)
            {
                ReSize(false);
            }
        }

        public void RemoveNElementsInsert(int index, int nElelements)
        {
            if (Lenght - index >= nElelements)
            {
                Lenght -= nElelements;

                for (int i = index; i < Lenght; i++)
                {
                    _array[i] = _array[i + nElelements];
                }

            }
            else
            {
                Lenght = index;
            }

            //if (Lenght != 0 && Lenght <= _array.Length / 2) ПОД ВОПРОСОМ??????
            //{
            //    ReSize(false);
            //}
        }

        public int SearchByValue(int value)
        {

            for (int i = 0; i < Lenght; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            if (index < Lenght && index >= 0)
            {

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void ReversArray()
        {
            int temp;
            int swapIndex;
            for (int i = 0; i < Lenght / 2; i++)
            {
                swapIndex = Lenght - i - 1;
                temp = _array[i];

                _array[i] = _array[swapIndex];
                _array[swapIndex] = temp;
            }
        }

        public int MaxIndexOfElement()
        {
            int maxIndexOfElement = 0;
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[maxIndexOfElement] < _array[i])
                {
                    maxIndexOfElement = i;
                }
            }

            return maxIndexOfElement;
        }
        public int MinIndexOfElement()
        {
            int minIndexOfElement = 0;
            for (int i = 1; i < Lenght; i++)
            {
                if (_array[minIndexOfElement] > _array[i])
                {
                    minIndexOfElement = i;
                }
            }

            return minIndexOfElement;
        }

        public int MaxElement()
        {
            return _array[MaxIndexOfElement()];
        }

        public int MinElement()
        {
            return _array[MinIndexOfElement()];
        }

        public void RemoveFirstElementByValue(int value)
        {
            RemoveAt(SearchByValue(value));
        }

        public void RemoveAllElementsByValue(int value)
        {
            int indexOfElements = SearchByValue(value);
            while (indexOfElements != -1)
            {
                RemoveAt(indexOfElements);
                indexOfElements = SearchByValue(value);
            }
        }

        private void ReSize(bool isUpOrDoun)
        {
            int newLength = isUpOrDoun ? (int)(_array.Length * 1.33d + 1) : (int)(_array.Length / 1.33d + 1);
            int[] tempArray = new int[newLength];
            for (int i = 0; i < Lenght; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }
    }
}



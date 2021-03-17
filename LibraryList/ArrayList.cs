using System;

namespace LibraryList
{
    public class ArrayList
    {

        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int el)
        {  
            Length = 0;
            _array = new int[10];

            AddFirst(el);
        }

        public ArrayList(int[] initArray)
        { if( !(initArray == null))
            {

            Length = 0;
            _array = new int[initArray.Length];

            for (int i = 0; i < initArray.Length; i++)
            {
                AddLast(initArray[i]);
            }
            }
            else
            {
                throw new ArgumentException("Ti she duurak? kuda null pihaech?");
            }
        }

        public int this[int index]
        {
            get { return _array[index]; }

            set
            {
                if (!(index >= Length || index <= 0))
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }
    
        public void AddLast(int value)
        {
            if (!(Length < _array.Length))
            {
                Resize((int)(_array.Length * 1.33d + 1));
            }

            _array[Length++] = value;
        }

        public void AddFirst(int value)
        {
            if (!(Length < _array.Length))
            {
                Resize((int)(_array.Length * 1.33d + 1));
            }

            Shift(Length, 0);

            _array[0] = value;
        }

        public void AddByIndex(int index, int value)
        {
            if (index >= 0 && index <= Length)
            {
                if (!(Length < _array.Length))
                {
                    Resize((int)(_array.Length * 1.33d + 1));
                }

                    Shift(Length, index);
                    _array[index] = value;
                
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast()
        {
            if (Length < _array.Length / 2)
            {
                Resize((int)(Length * 1.33d + 1));
            }

            if (!(Length == 0))
            {
                Length--;
            }
        }

        public void RemoveFirst()
        {
            if (!(Length >= _array.Length / 2))
            {
                Resize((int)(Length * 1.33d + 1));
            }

            if (!(Length == 0))
            {
                Shift(Length, 0, 1 );
            }
        }

        public void RemoveByIndex(int index)
        {
            if (!(index < 0 || index > Length))
            {
                if (!(Length > _array.Length / 2))
                {
                    Resize((int)(Length * 1.33d + 1));
                }

                if (!(Length == 0))
                {
                    Shift(Length, index, 1);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast(int nElelements)
        {
            if (Length >= nElelements)
            {
                Length -= nElelements;
            }
            else
            {
                Length = 0;
            }

            if (!(Length > _array.Length / 2))
            {
                Resize((int)(Length * 1.33d + 1));
            }
        }

        public void RemoveFirst(int nElelements)
        {
            if (!(Length <= nElelements))
            {
                Shift(Length, 0, nElelements);
            }
            else
            {
                Length = 0;
            }
          
            if (!(Length >= _array.Length / 2))
            {
                Resize((int)(Length * 1.33d + 1));
            }
        }

        public void RemoveByIndex(int index, int nElelements)
        {
            if (Length - index >= nElelements)
            {
                Shift(Length, index, nElelements);

            }
            else
            {
                Length = index;
            }

            if (!(Length >= _array.Length / 2))
            {
                Resize((int)(Length * 1.33d + 1));
            }
        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Revers()
        {
            int temp;
            int swapIndex;
            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                temp = _array[i];

                _array[i] = _array[swapIndex];
                _array[swapIndex] = temp;
            }
        }

        public int FindMaxIndex()
        {
            int maxIndexOfElement = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[maxIndexOfElement] < _array[i])
                {
                    maxIndexOfElement = i;
                }
            }

            return maxIndexOfElement;
        }

        public int FindMinIndex()
        {
            int minIndexOfElement = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[minIndexOfElement] > _array[i])
                {
                    minIndexOfElement = i;
                }
            }

            return minIndexOfElement;
        }

        public int FindMaxElement()
        {
            return _array[FindMaxIndex()];
        }

        public int FindMinElement()
        {
            return _array[FindMinIndex()];
        }

        public void RemoveByValue(int value)
        {
            RemoveByIndex(GetIndexByValue(value));
        }

        public void RemoveAllByValue(int value)
        {
            int indexOfElements = GetIndexByValue(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }
        }

        private void Resize( int newLength)
        {
            int[] tempArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        //shift to the right ------->
        private void Shift( int lenght,int index) {
           
            for (int i = lenght-1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }

            Length++;
        }

        // left shift    <-------
        private void Shift(int lenght, int index, int nElements)
        {

            for (int i = index; i < lenght-1; i++)
            {
                _array[i] = _array[i + nElements];
            }

            Length-= nElements;
        }

        public override bool Equals(object obj)
        {
            ArrayList list = (ArrayList)obj;
            if (this.Length != list.Length)
            {

                return false;
            }
         
            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != list._array[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}



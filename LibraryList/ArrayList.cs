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

        public void Add(int value)
        {
            if (Lenght == _array.Length) {
                UpSize();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        public void AddInStart(int value)
        {
            if (Lenght != 0)
            {
                if (Lenght == _array.Length)
                {
                    UpSize();
                }

                int[] tempArray = new int[_array.Length + 1];
                tempArray[0] = value;
                int j = 0;
                for (int i = 0; i < _array.Length; i++)
                {
                    tempArray[++j] = _array[i];
                }

                _array = tempArray;

            }
            else
            {
                _array[0] = value;
            }

            Lenght++;
        }

        public void Insert(int index, int value)
        {
            if (index < Lenght)
            {
                if (Lenght == _array.Length)
                {
                    UpSize();
                }

                int[] tempArray = new int[_array.Length + 1];
                int j = 0;
                for (int i = 0; i < _array.Length; i++)
                {
                    if (i == index)
                    {
                        tempArray[j++] = value;
                    }
                    tempArray[j++] = _array[i];
                }

                _array = tempArray;
                Lenght++;
            }
            else
            {

            throw new IndexOutOfRangeException("Index Out Of Randge ");

            }
        }

        public int IndexAccess(int index)
        {
            if(index < Lenght)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
        }

        public void RemoveLast()
        {   if (Lenght != 0) { 
            int newLength = _array.Length - 1;
            if (Lenght < _array.Length / 2)
            {
                newLength = (int)(_array.Length / 1.33d + 1);
            }

            int[] tempArray = new int[newLength];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
            Lenght--;
            } else
            {
                throw new Exception("Array pustoi");
            }
        }

        public void RemoveFirst()
        {
            if (Lenght != 0)
            {
                int newLength = _array.Length - 1;
                if (Lenght < _array.Length / 2)
                {
                    newLength = (int)(_array.Length / 1.33d + 1);
                }

                int[] tempArray = new int[newLength];

                int j = 0;
                for (int i = 1; i < tempArray.Length; i++)
                {
                    tempArray[j++] = _array[i];
                }

                _array = tempArray;
                Lenght--;
            } else
            {
                throw new Exception("Array pustoi");
            }
        }

        public void RemoveAt(int index)
        {
            if (Lenght != 0)
            {
                int newLength = _array.Length - 1;
                if (Lenght < _array.Length / 2)
                {
                    newLength = (int)(_array.Length / 1.33d + 1);
                }

                int[] tempArray = new int[newLength];

                int j = 0;
                for (int i = 0; i < tempArray.Length; i++)
                {

                    if (i != index)
                    {
                        tempArray[j++] = _array[i];
                    }
                }

                _array = tempArray;
                Lenght--;
            }
            else
            {
                throw new Exception("Array pustoi");
            }
        }
        
        public void RemoveNElementsFromEnd(int nElelements)
        {
            if (Lenght != 0)
            {
                int newLength = Lenght - nElelements;
                
                int[] tempArray = new int[newLength];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
                Lenght-= nElelements;
            }
            else
            {
                throw new Exception("Array pustoi");
            }
        }

        public void RemoveNElementsAt(int index, int nElelements)
        {
            if (Lenght >= (nElelements + index))
            {
                int newLength = Lenght - nElelements;
                int SwapValue = nElelements;
                int[] tempArray = new int[newLength];

                int j = 0;
                for (int i = 0; i < tempArray.Length; i++)
                {

                    if (i != index)
                    {
                        tempArray[i] = _array[j++];
                    }
                    else
                    {
                        j += SwapValue;
                        tempArray[i] = _array[j++];
                    }
                }

                _array = tempArray;
                Lenght -= nElelements;
            }
            else
            {
                throw new Exception("Array pustoi");
            }
        }
        public void RemoveNElementsFromStart(int nElelements)
        {
            if (Lenght >= nElelements)
            {
                int newLength = Lenght - nElelements;
                int SwapValue = nElelements;
                int[] tempArray = new int[newLength];
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = _array[SwapValue++];
                }

                _array = tempArray;
                Lenght -= nElelements;
            }
            else
            {
                throw new Exception("Array pustoi");
            }
        }
        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            int[] tempArray = new int[newLength];
            for (int i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }
    }
}
   


using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryList
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                return GetCurrentNode(index).Value;
            }
            set
            {
                GetCurrentNode(index).Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (!(values is null))
            {

                Length = values.Length;
                if (values.Length != 0)
                {
                    _root = new Node(values[0]);
                    _tail = _root;

                    for (int i = 1; i < values.Length; i++)
                    {
                        _tail.Next = new Node(values[i]);
                        _tail = _tail.Next;
                    }
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new ArgumentException(" Array is Null");
            }
        }

        public void AddLast(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }

            Length++;
        }

        public void AddLast(LinkedList list)
        {
        }

        public void AddFirst(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
        }

        public void AddFirst(LinkedList list)
        {
        }


        public void AddByIndex(int index, int value)
        {
            if (Length != 0)
            {
                Node ByIndex = new Node(value);

                Node current = GetCurrentNode(index-1);

                ByIndex.Next = current.Next;
                current.Next = ByIndex;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }

            Length++;
        }

        public void AddByIndex(int index, LinkedList list)
        {

        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                Node current = GetCurrentNode(Length - 2);
             
                current.Next = current.Next.Next;
                _tail = current;
                Length--;
            }
        }

        public void RemoveFirst()
        {
            _root = _root.Next;
        }

        public void RemoveByIndex(int index)
        {
            Node current = GetCurrentNode(index-1);

            current.Next = current.Next.Next;
            Length--;
        }

        public void RemoveLast(int nElements)
        {
        }

        public void RemoveFirst(int nElements)
        {

        }

        public void RemoveByIndex(int index, int nElements)
        {

        }
        ////GetIndexByValue for Maksim
        //// indexOf for Svyatoslav
        //public int GetIndexByValue(int value)
        //{
        //}

        //public void Reverse()
        //{

        //}

        //// MaxI for Svyatoslav
        //// FindMaxIndex for Maksim
        //public int FindMaxIndex()
        //{
        //}


        //// MinI for Svyatoslav
        //// FindMinIndex for Maksim
        //public int FindMinIndex()
        //{
        //}

        //// Max for Svyatoslav
        //// FindMaxElement for Maksim
        //public int FindMaxElement()
        //{

        //}

        //// Min for Svyatoslav
        //// FindMinElement for Maksim
        //public int FindMinElement()
        //{

        //}

        //public void RemoveByValue(int value)
        //{

        //}

        //public void RemoveAllByValue(int value)
        //{

        //}

        //public void SortAscendingInsert()
        //{

        //}

        //public void SortDescendingInsert()
        //{
        //}

        ////shift to the right ------->
        //private void ShiftRight(int index, int nElements)
        //{
        //    for (int i = Length - 1; i > index; --i)
        //    {
        //        _array[i] = _array[i - nElements];
        //    }
        //}

        //// left shift    <-------
        //private void ShiftLeft(int index, int nElements)
        //{
        //    for (int i = index; i < Length; ++i)
        //    {
        //        _array[i] = _array[i + nElements];
        //    }
        //}
        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";
            
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                
                return s;
            }
         
            return String.Empty;
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
        
            if(!(this.Length == list.Length && this.Length == 0))
            {

            if (this.Length != list.Length)
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }

                currentThis = currentThis.Next;
                currentList = currentList.Next;

            }
            while (!(currentThis is null));
            }

            return true;
        }

        private Node GetCurrentNode(int index)
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }
    }
}





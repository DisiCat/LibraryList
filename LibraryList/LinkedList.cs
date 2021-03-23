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
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
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

        public LinkedList(int[] values) // 1/2/3
        {
            if (!(values is null))
            {
                if (values.Length != 0)
                {

                    for (int i = 0; i < values.Length; i++)
                    {
                        AddLast(values[i]);
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

            ++Length;
        }
         
        public void AddLast(LinkedList list)
        {
            if (!(list is null))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    AddLast(list[i]);
                }
            }
            else
            {

                throw new ArgumentException(" List is null");
            }

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
            if (!(list is null))
            {
                for (int i = list.Length - 1; i >= 0; --i)
                {
                    AddFirst(list[i]);
                }
            }
            else
            {

                throw new ArgumentException(" List is null");
            }
        }


        public void AddByIndex(int index, int value)
        {
            if (Length != 0)
            {
                Node ByIndex = new Node(value);

                Node current = GetNodeByIndex(index - 1);

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
            RemoveByIndex(Length - 1);
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (Length != 0)
            {
                if (Length != 1)
                {

                    Node current = GetNodeByIndex(index - 1);

                    current.Next = current.Next.Next;
                    _tail = current;

                }
                else
                {
                    _root = null;
                    _tail = null;
                }
                --Length;
            }
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
            if (obj is LinkedList || obj is null)
            {
                LinkedList list = (LinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    Node currentThis = this._root;
                    Node currentList = list._root;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isEqual = false;
                            break;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not LinkedList");
        }

        private Node GetNodeByIndex(int index)
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





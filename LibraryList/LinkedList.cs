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

        public LinkedList(int[] values)
        {
            if (!(values is null))
            {
                Length = 0;

                if (values.Length != 0)
                {
                    for (int i = 0; i < values.Length; ++i)
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
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    Node ByIndex = new Node(value);

                    Node current = GetNodeByIndex(index - 1);

                    ByIndex.Next = current.Next;
                    current.Next = ByIndex;

                    Length++;
                }
                else
                {
                    AddFirst(value);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }

        public void AddByIndex(int index, LinkedList newList)
        {
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
                {
                    if (newList.Length != 0)
                    {
                        Node current = GetNodeByIndex(index - 1);

                        newList._tail.Next = current.Next;
                        _tail = current;
                        int newLengthList = newList.Length + Length - index;
                        Length = index;

                        for (int i = 0; i < newLengthList; i++)
                        {
                            AddLast(newList[i]);
                        }

                        newList._tail.Next = null;

                    }
                }
                else
                {
                    AddFirst(newList);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                RemoveByIndex(Length - 1);
            }
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
            if ((index == Length && Length == 0) || (index >= 0 && index < Length))
            {
                if (index != 0)
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
                else
                {
                    if (Length != 0)
                    {
                        _root = _root.Next;
                        --Length;
                    }
                }

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveLast(int nElements)
        {
            if (nElements >= 0)
            {
                if (Length != 0 && nElements !=0)
                {
                    if (Length - nElements >= 0)
                    {
                        Length -= nElements;
                        _tail = GetNodeByIndex(Length - 1);
                        _tail.Next = null;
                    }
                    else
                    {
                        Length = 0;
                        _root = null;
                        _tail = null;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (nElements >= 0)
            {
                if (Length != 0 && nElements != 0)
                {
                    if (Length - nElements >= 0)
                    {
                        _root = GetNodeByIndex(nElements);
                        Length -= nElements;
                    }
                    else
                    {
                        Length = 0;
                        _root = null;
                        _tail = null;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }

        }

        public void RemoveByIndex(int index, int nElements)
        {
            if ((index >= 0 && index < Length) && nElements >= 0)
            {
                if (Length != 0 || nElements != 0)
                {
                    if (index != 0)
                    {
                        if (Length - index - nElements > 0)
                        {
                            Node sectionStart = GetNodeByIndex(index - 1);
                            Node sectionEnd = GetNodeByIndex(index + nElements);

                            sectionStart.Next = sectionEnd;
                            Length -= nElements;
                        }
                        else
                        {
                            Node sectionStart = GetNodeByIndex(index - 1);
                            sectionStart.Next = null;
                            _tail = sectionStart;
                            Length = index;
                        }
                    }
                    else
                    {
                        RemoveFirst(nElements);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong arguments");
            }
        }
        //GetIndexByValue for Maksim
        // indexOf for Svyatoslav
        public int GetIndexByValue(int value)
        {
            Node currentNode = _root;

            for (int i = 0; i < Length; ++i)
            {
                if (currentNode.Value == value)
                {
                    return i;
                }

                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    _tail.Next = _root;
                    Node stepByOne = _root.Next;
                    Node stepBySecond = _root.Next.Next;
                    _root.Next = null;
                    while (!(stepBySecond is null))
                    {
                        if (stepBySecond.Next is null)
                        {
                            _tail = _tail.Next;
                        }

                        stepByOne.Next = _root;
                        _root = stepByOne;
                        stepByOne = stepBySecond;
                        stepBySecond = stepBySecond.Next;
                    };
                }
            }
        }

        //// MaxI for Svyatoslav
        //// FindMaxIndex for Maksim
        public int FindMaxIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int maxIndex = 0;
                int maxValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                        maxIndex = i;
                    }

                    current = current.Next;
                }

                return maxIndex;
            }

            throw new ArgumentException("List is null");
        }

        //// MinI for Svyatoslav
        //// FindMinIndex for Maksim
        public int FindMinIndex()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int minIndex = 0;
                int minValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                        minIndex = i;
                    }

                    current = current.Next;
                }

                return minIndex;
            }

            throw new ArgumentException("List is null");
        }


        // Max for Svyatoslav
        // FindMaxElement for Maksim
        public int FindMaxElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int maxValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (maxValue < current.Next.Value)
                    {
                        maxValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }

            throw new ArgumentException("List is null");
        }

        //// Min for Svyatoslav
        //// FindMinElement for Maksim
        public int FindMinElement()
        {
            if (Length != 0 || this is null)
            {
                Node current = _root;
                int minValue = _root.Value;

                for (int i = 1; i < Length; i++)
                {
                    if (minValue > current.Next.Value)
                    {
                        minValue = current.Next.Value;
                    }

                    current = current.Next;
                }

                return minValue;
            }

            throw new ArgumentException("List is null");
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if (index != -1)
            {
                RemoveByIndex(index);
            }

        }

        public void RemoveAllByValue(int value)
        {
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                index = GetIndexByValue(value);
            }

        }

        //public void SortAscendingInsert()
        //{

        //}

        //public void SortDescendingInsert()
        //{
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
            if (index >= 0 || index < Length)
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                return current;
            }

            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}





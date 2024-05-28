using System.Collections;
using UnsafeLinkedList;

namespace UnsafeLinkedLists
{
    public unsafe struct UnsafeLinkedList : IEnumerable
    {
        private Node* _head;
        private Node* _tail;
        private Node* _buffer;
        private int _bufferSize;
        private int _inititialBufferSize;
        public int Count { get; set; }
        public UnsafeLinkedList(int bufferSize, Node* buffer)
        {
            _head = _tail = null;
            _buffer = buffer; 
            _bufferSize = bufferSize;
            _inititialBufferSize = bufferSize;
            Count = 0;
        }
        public void AddFirst(int element)
        {
            if (_bufferSize > 0)
            {
                _bufferSize--;
                Node* node = _buffer + _bufferSize;
                node->Data = element;

                if (_head == null)
                {
                    _head = _tail = node;
                }
                else
                {
                    node->Next = _head;
                    _head = node;
                }
                Count++;
            }

            else
            {
                throw new InvalidOperationException("Буфер заполнен");
            }
        }
        public void AddLast(int data)
        {
            if (_bufferSize > 0)
            {
                _bufferSize--;
                Node* node = _buffer + _bufferSize;
                node->Data = data;

                if (_head == null)
                {
                    _head = _tail = node;
                }
                else
                {
                    _tail->Next = node;
                    _tail = node;
                }
                Count++;
            }

            else
            {
                throw new InvalidOperationException("Буфер заполнен");
            }
        }
        public void RemoveFirst()
        {
            if (_head != null)
            {
                Node* temp = _head;
                _head = _head->Next;

                if (_head == null)
                {
                    _tail = null;
                }

                _buffer[_bufferSize] = *temp; 
                _bufferSize++; 
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (_head != null)
            {
                Node* current = _head;
                while (current->Next != _tail)
                {
                    current = current->Next;
                }
                current->Next = null; 
                _tail = current; 

                _buffer[_bufferSize] = *_tail;
                _bufferSize++;
                Count--;
            }
        }
        public void Clear()
        {
            _head = _tail = null;
            _bufferSize = _inititialBufferSize;
            Count = 0;
        }
        public bool Contains(int element)
        {
            if (_head is null)
            {
                return false;
            }

            Node* current = _head;

            while (current != null)
            {
                if (current->Data == element)
                {
                    return true;
                }
                current = current->Next;
            }

            return false;
        }
        public IEnumerator GetEnumerator()
        {
            return new UnsafeLinkedListEnumerator(_head);
        }
    }
}

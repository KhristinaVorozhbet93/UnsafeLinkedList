using System.Collections;
using UnsafeLinkedLists;

namespace UnsafeLinkedList
{
    public unsafe struct UnsafeLinkedListEnumerator : IEnumerator
    {
        private Node* _current;

        public UnsafeLinkedListEnumerator(Node* head)
        {
            _current = head;
        }

        public bool MoveNext()
        {
            if (_current != null)
            {
                _current = _current->Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = null;
        }

        public object Current
        {
            get
            {
                if (_current == null)
                {
                    throw new InvalidOperationException();
                }
                return _current->Data;
            }
        }
    }
}

namespace UnsafeLinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                Node* buffer = stackalloc Node[5];
                UnsafeLinkedList unsafeLinkedList = new UnsafeLinkedList(5, buffer);
                unsafeLinkedList.AddLast(9);
                unsafeLinkedList.AddLast(10);

                Console.WriteLine(unsafeLinkedList.Contains(9));
                Console.WriteLine(unsafeLinkedList.Contains(10));

                unsafeLinkedList.RemoveFirst();

                unsafeLinkedList.Clear();

                Console.WriteLine(unsafeLinkedList.Count);
            }
        }
    }
}



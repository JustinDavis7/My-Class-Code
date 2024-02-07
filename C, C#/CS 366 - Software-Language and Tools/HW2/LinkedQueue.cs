namespace HW2
{
    public class LinkedQueue<T> : QueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        public T Push(T element)
        {
            if (element == null)
            {
                throw new ();
            }

            if (IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                rear = front = temp;
            }
            else
            {
                Node<T> temp = new Node<T>(element, null);
                rear.next = temp;
                rear = temp;
            }
            return element;
        }

        public T Pop()
        {
            T temp = default(T);
            if (IsEmpty())
            {
                //throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                temp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                temp = front.data;
                front = front.next;
            }

            return temp;
        }

        public T Peek()
        {
            //if (IsEmpty())
                //throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            return front.data;
        }

        public bool IsEmpty()
        {
            if (front == null && rear == null)
            {
                return true;
            }
            return false;
        }
    }
}
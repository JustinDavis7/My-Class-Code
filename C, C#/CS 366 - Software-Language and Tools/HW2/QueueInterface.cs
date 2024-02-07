using System;
namespace HW2
{
    public interface QueueInterface<T>
    {
        T Push(T element);
        T Pop();
        T Peek();
        bool IsEmpty();
    }
}
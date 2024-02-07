using System;
namespace HW2
{
    public class QueueUnderflowExcepttion : Exception
    {
        public void QueueUnderflowException()
        {
            _ = new SystemException();
        }

        public void QueueUnderflowException(string message)
        {
            _ = new SystemException(message);
        }
    }
}
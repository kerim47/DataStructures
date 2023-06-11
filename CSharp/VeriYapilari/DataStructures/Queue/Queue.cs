using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class Queue<T>
    {
        // interface tanimlanmasi
        private readonly IQueue<T> queue;

        // Kuyruk yapisi adedi
        public int Count => queue.Count;

        /// <summary>
        /// Constructor Kuyruk tip tanimlanmasi
        /// Type girilmezse varsayılan olarak Array olur.
        /// </summary>
        /// <param name="type">Kuyruk tipi</param>
        public Queue(QueueType type = QueueType.Array)
        {
            if (type == QueueType.Array)
            {
                queue = new QueueArray<T>();
            }
            else if(type == QueueType.LinkedList)
            {
                queue = new LinkedlistQueue<T>();
            }
        }

        /// <summary>
        /// Kuyruğun son elemaninda
        /// </summary>
        /// <param name="Item"></param>
        public void EnQueue(T Item)
        {
            queue.EnQueue(Item);
        }

        public T DeQueue()
        {
            return queue.DeQueue();
        }

        public T Peek()
        {
            return queue.Peek();
        }
    }

    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T Item);
        T DeQueue();
        T Peek();
    }

    public enum QueueType
    {
        Array = 0,      // List<T>
        LinkedList = 1, // DoublyLinkedList<T>
    }

}



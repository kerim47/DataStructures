using DataStructures.LinkedList.DoublyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Çift yonlu bağlı listenin başını tutar.
        /// </summary>
        public DoublyLinkedListNode <T> Head { get; set; }

        /// <summary>
        /// Çift yonlu bağlı listenin sonunu tutar.
        /// </summary>
        public DoublyLinkedListNode <T> Tail { get; set; }

        public DoublyLinkedList() { }

        /// <summary>
        /// Verilen bir koleksiyonu kullanarak çift yönlü bağlı listeyi oluşturan bir yapılandırıcı method.
        /// </summary>
        /// <param name="collection">Bağlı listeye eklenmek istenen öğelerin bulunduğu bir koleksiyon</param>
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                AddLast(item);
        }

        /// <summary>
        /// Head Null olup olmadiginin sorgular
        /// </summary>
        private bool IsHeadNull => Head == null;

        /// <summary>
        /// Tail Null olup olmadiginin sorgular
        /// </summary>
        private bool IsTailNull => Tail == null;

        /// <summary>
        /// Degeri çift yonlu bagli listenin sonuna ekler.
        /// </summary>
        /// <param name="value">Eklenecek eleman</param>
        public void AddFirst(T value)
        {
            // Yeni bir dugum olustur.
            var newNode = new DoublyLinkedListNode<T>(value);

            // Head null değilse kuyruk basini new node olarak ayarlar
            if (!IsHeadNull)
                Head.Prev = newNode;

            // Yeni nodu guncelle
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            // Tail null ise Head tail yap
            if (IsTailNull)
                Tail = Head;
        }

        /// <summary>
        /// Dugumu Çift yonlu bagli listeye ekler.
        /// </summary>
        /// <param name="newNode"></param>
        public void AddFirst(DoublyLinkedListNode<T> newNode)
        {
            if (!IsHeadNull)
                Head.Prev = newNode;

            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (IsTailNull)
                Tail = Head;
        }

        /// <summary>
        /// Degeri çift yonlu bagli listenin sonuna ekler.
        /// </summary>
        /// <param name="value">Eklenecek eleman</param>
        public void AddLast(T value)
        {
            var new_node = new DoublyLinkedListNode<T>(value);
            if (IsTailNull)
            {
                AddFirst(new_node);
                return;
            }
            Tail.Next = new_node;

            new_node.Next = null;
            new_node.Prev = Tail;
            Tail = new_node;
            return;
        }

        /// <summary>
        /// Yeni bir dugumu çift yonlu bagli listenin sonuna ekler.
        /// </summary>
        /// <param name="newNode">Eklenecek dugum</param>
        public void AddLast(DoublyLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException();
            }
            if (IsHeadNull)
            {
                Head = newNode;
                return;
            }
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        /// <summary>
        /// Cift yonlu bagli listede referans dugumden sonra degeri ekler
        /// </summary>
        /// <param name="refNode">Referans Dugum</param>
        /// <param name="Value">Eklenecek deger</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddAfter(DoublyLinkedListNode<T> refNode, T Value)
        {
            var newNode = new DoublyLinkedListNode<T>(Value);
            if (refNode == null)
                throw new ArgumentNullException();

            if(refNode == Head && refNode == Tail )
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Next = null;
                newNode.Prev = refNode;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if(refNode != Tail)
            {
                newNode.Next = refNode.Next;
                newNode.Prev = refNode;

                refNode.Next = newNode;
                refNode.Next.Prev = newNode;
            }
            else
            {
                refNode.Next = newNode;

                newNode.Prev = refNode;
                newNode.Next = null;

                Tail = newNode;
                return;
            }
        }

        /// <summary>
        /// Cift yonlu bagli listede dugumun arkasina yeni bir dugum ekler.
        /// </summary>
        /// <param name="refNode">Referans Dugum</param>
        /// <param name="newNode">Yeni Dugum</param>
        /// <exception cref="ArgumentNullException">Referans dugum null oldugunda fırlatılır.</exception>
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {

            if (refNode == null)
                throw new ArgumentNullException();

            if(refNode == Head && refNode == Tail )
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Next = null;
                newNode.Prev = refNode;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if(refNode != Tail)
            {
                newNode.Next = refNode.Next;
                newNode.Prev = refNode;

                refNode.Next = newNode;
                refNode.Next.Prev = newNode;
            }
            else
            {
                refNode.Next = newNode;

                newNode.Prev = refNode;
                newNode.Next = null;

                Tail = newNode;
                return;
            }
        }

        /// <summary>
        /// Cift yonlu bagli listede dugumun arkasina yeni bir dugum ekler.
        /// </summary>
        /// <param name="refNode">Referans Dugum</param>
        /// <param name="Value">Eklenecek Deger/param>
        /// <exception cref="ArgumentNullException">Referans dugum null oldugunda fırlatılır.</exception>
        public void AddBefore(DoublyLinkedListNode<T> refNode, T Value)
        {
            var newNode = new DoublyLinkedListNode<T>(Value);

            if (refNode == null)
                throw new ArgumentNullException();

            if(refNode == Head && refNode == Tail )
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Next = null;
                newNode.Prev = refNode;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if(refNode != Tail)
            {
                newNode.Next = refNode.Next;
                newNode.Prev = refNode;

                refNode.Next = newNode;
                refNode.Next.Prev = newNode;
            }
            else
            {
                refNode.Next = newNode;

                newNode.Prev = refNode;
                newNode.Next = null;

                Tail = newNode;
                return;
            }
        }

        /// <summary>
        /// Çift yonlu bagli listede belirtilen referans dugumunun onune yeni bir dugum ekler
        /// </summary>
        /// <param name="refNode">Referans Dugum</param>
        /// <param name="newNode">Yeni Dugum</param>
        /// <exception cref="ArgumentNullException">Referans dugum null oldugunda fırlatılır.</exception>
        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            // Referans dugum null mu? 
            if (refNode == null)
                throw new ArgumentNullException();

            // referans dugum hem kuyruk hemde bas dugum mu?
            // Yani liste tek dugum mu
            if (refNode == Tail && refNode == Head)
            {
                newNode.Next = refNode;
                newNode.Prev = null;

                refNode.Prev = newNode;
                refNode.Next = null;

                Head = newNode;
                Tail = refNode;
                return;
            }

            // referans dugumun oncesi null mu yani refNode Head mi
            if (refNode.Prev == null)
            {
                newNode.Next = refNode;
                newNode.Prev = null;
                
                refNode.Prev = newNode;

                Head = newNode;
            }
            else
            {
                newNode.Next = refNode;
                newNode.Prev = refNode.Prev;

                refNode.Prev.Next = newNode;
                refNode.Prev = newNode;
            }
        }

        /// <summary>
        // Ilk dugumden itibaren dugumleri siler.
        /// </summary>
        /// <returns>T tipinde value degeri dondurur</returns>
        /// <exception cref="Exception">Liste bossa hata firlatilir.</exception>
        public T RemoveFirst()
        {
            if (IsHeadNull)
                throw new Exception("UnderFlow! nothing to remove.");
            var Value = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return Value;
        }

        /// <summary>
        /// Son dugumden itibaren siler.
        /// </summary>
        /// <returns>T value</returns>
        /// <exception cref="Exception"></exception>
        public T RemoveLast()
        {
            if (IsHeadNull)
                throw new Exception("UnderFlow! nothing to remove.");

            var Value = Tail.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            return Value;
        }

        /// <summary>
        /// Bagli listede degeri olan dugumu siler.
        /// </summary>
        /// <param name="Value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Remove(T Value)
        {
            if (IsHeadNull)
                throw new ArgumentNullException();
            if (Value == null)
                throw new ArgumentNullException();
            if (Head == Tail)
            {
                if ((Head.Value).Equals(Value))
                {
                    RemoveFirst();
                }
                return;
            }

            var current = Head;

            while (current != null)
            {
                if(current.Value.Equals(Value))
                {
                    // current ilk eleman ? 
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    // current son eleman ? 
                    else if(current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    // current arada bir eleman ise
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }

            throw new ArgumentException("The value can not be found in the list.");
        }

        public IEnumerator GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

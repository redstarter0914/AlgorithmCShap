using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest.LinkedList
{
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public ListNode<T> Head { get; }

        public ListNode<T> First => Head.Next;

        public int Length { get; private set; }

        public SingleLinkedList()
        {
            Head = new ListNode<T>(default(T));
        }

        public SingleLinkedList(params T[] list)
        {
            Head = new ListNode<T>(default(T));
            if (list == null)
            {
                return;
            }
            var p = Head;
            foreach (var item in list)
            {
                var q = new ListNode<T>(item);
                p.Next = q;
                p = q;
            }

            //Head = p;
            Length = list.Length;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="position"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public ListNode<T> Insert(int position, T newItem)
        {
            if (position < 1 || position > Length + 1)
            {
                throw new IndexOutOfRangeException("Position must be in bound of list");
            }

            var p = Head;
            int j = 1;
            while (p != null && j < position)
            {
                p = p.Next;
                ++j;
            }

            var newNode = new ListNode<T>(newItem);
            newNode.Next = p.Next;
            p.Next = newNode;

            Length++;

            return newNode;

        }
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public ListNode<T> Find(int position)
        {
            ListNode<T> p = First;
            int j = 1;
            while (p != null && j < position)
            {
                p = p.Next;
                j++;
            }

            if (p == null || j > position)
            {
                return null;
            }

            return p;
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public ListNode<T> Find(T elem)
        {
            ListNode<T> p = Head.Next;
            while (p != null)
            {
                if (p.Value.CompareTo(elem) == 0)
                {
                    return p;
                }
                p = p.Next;
            }

            return null;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public ListNode<T> Delete(int position)
        {
            if (position < 1 | position > Length)
            {
                return null;
            }

            var p = First;
            int j = 1;
            while (p != null && j < position - 1)
            {
                p = p.Next;
                ++j;
            }

            var q = p.Next;
            p.Next = q.Next;

            Length--;

            return q;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public ListNode<T> Delete(T elem)
        {
            ListNode<T> p = Head;
            while (p.Next != null && p.Next.Value.CompareTo(elem) != 0)
            {
                p = p.Next;
            }

            if (p.Next == null)
            {
                return null;
            }

            var q = p.Next;
            p.Next = q.Next;

            Length--;

            return q;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            var p = Head;
            while (p.Next != null)
            {
                var q = p.Next;
                p.Next = null;

                p = q;
            }

            Length = 0;
        }

        /// <summary>
        /// 链表反转
        /// </summary>
        public void Reverse()
        {
            if (Length <= 1) return;

            ListNode<T> p = First;
            ListNode<T> q = First.Next;

            ListNode<T> r = null;

            p.Next = null;
            while (q != null)
            {
                r = q.Next;
                q.Next = p;
                p = q;
                q = r;
            }

            Head.Next = p;
        }

        /// <summary>
        /// 环检测
        /// </summary>
        /// <returns></returns>
        public bool HasCycle()
        {
            if (Length == 0) return false;

            var slow = Head.Next;
            var fast = Head.Next.Next;

            while (fast != null && slow != null && fast != slow)
            {
                fast = fast.Next?.Next;
                slow = slow.Next;
            }

            bool result = fast == slow;

            return result;
        }

        /// <summary>
        /// 合并两个有序链表(从小到大)
        /// </summary> 
        /// <param name="linkedList"></param>
        /// <returns></returns>
        public SingleLinkedList<T> Merge(SingleLinkedList<T> linkedList)
        {
            if (linkedList == null) return null;

            var root = new SingleLinkedList<T>();
            // 总是向新链表的尾结点
            ListNode<T> pointer = root.Head;

            var head1 = linkedList.First;
            var head2 = this.First;

            while (head1 != null && head2 != null)
            {
                if (head1.Value.CompareTo(head2.Value) < 0)
                {
                    pointer.Next = head1;
                    head1 = head1.Next;
                }
                else
                {
                    pointer.Next = head2;
                    head2 = head2.Next;
                }

                pointer = pointer.Next;
            }

            if (head1 != null)
            {
                pointer.Next = head1;
            }
            if (head2 != null)
            {
                pointer.Next = head2;
            }

            return root;
        }

        /// <summary>
        /// 链表的中间结点
        /// </summary>
        /// <remarks>
        /// 思路： 利用快慢指针，快指针步长2，慢指针步长1，当快指针到达尾结点时，慢指针正好到达中间结点 
        /// </remarks>
        /// <returns></returns>
        public ListNode<T> FindMiddleNode()
        {
            if (First?.Next == null) return null;

            ListNode<T> slowPointer = First;
            ListNode<T> fastPointer = First.Next;

            while (fastPointer.Next?.Next != null)
            {
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
            }

            slowPointer = slowPointer.Next;

            return slowPointer;

        }
    }
}

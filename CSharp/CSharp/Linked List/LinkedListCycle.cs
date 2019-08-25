using System.Collections.Generic;

namespace CSharp.Linked_List
{
	/// <summary>
	/// 如何判断一个单链表是否有环? 有环的话返回进入环的第一个节点, 无环的话返回空. 
	/// 如果链表的长度为N, 请做到时间复杂度O(N), 额外空间复杂度O(1)
	/// </summary>
	class LinkedListCycle_Solution
	{
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null)
				return null;

			ListNode slow = head, fast = head;

			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
				if (slow != fast)
					break;
			}

			if (fast == null || fast.next == null)
				return null;

			fast = head;
			while (slow != fast)
			{
				fast = fast.next;
				slow = slow.next;
			}
			return slow;
		}
		public static ListNode CreateLinkedList(int[] arr)
		{
			if (arr.Length == 0)
				return null;

			ListNode head = new ListNode(arr[0]);
			ListNode curNode = head;
			for (int i = 1; i < arr.Length; i++)
			{
				curNode.next = new ListNode(arr[i]);
				curNode = curNode.next;
			}
			return head;
		}

		public static ListNode Tail(ListNode head)
		{
			if (head == null)
				return null;

			ListNode cur = head;
			while (cur.next != null)
				cur = cur.next;
			return cur;
		}

		public static ListNode CreateCycleLinkedList(int[] arr, int pos)
		{
			ListNode head = CreateLinkedList(arr);
			ListNode tail = Tail(head);
			ListNode cur = head;

			while (pos-- > 0)
				cur = cur.next;
			tail.next = cur;
			return head;
		}

		//static void Main()
		//{
		//	ListNode head = CreateLinkedList(new int[] { -4 });
		//	ListNode aa = new LinkedListCycle_Solution().DetectCycle(head);
		//}
	}

	class LinkedListCycle_Solution2
	{
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null)
				return null;

			ListNode cur = head;
			HashSet<ListNode> set = new HashSet<ListNode>();
			while (cur != null)
			{
				if (set.Contains(cur))
					return cur;
				set.Add(cur);
				cur = cur.next;
			}
			return null;
		}
	}
}

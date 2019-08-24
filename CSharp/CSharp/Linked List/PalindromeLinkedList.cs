using System.Collections.Generic;

namespace CSharp.Linked_List
{
	/// <summary>
	/// 判断一个链表是否为回文结构
	/// 例如:
	/// 链表1->2->3->2->1,是回文结构，返回true;链表1->2->3->1不是回文结构,返回false.
	/// </summary>
	class PalindromeLinkedList_Solution
	{
		public bool IsPalindrome(ListNode head)
		{
			ListNode cur = head;
			Stack<ListNode> stack = new Stack<ListNode>();

			while (cur != null)
			{
				stack.Push(cur);
				cur = cur.next;
			}

			cur = head;
			while (cur != null)
			{
				if (cur.val != stack.Pop().val)
					return false;
				cur = cur.next;
			}
			return true;
		}
	}
	class PalindromeLinkedList_Solution2
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null)
				return true;

			ListNode slow = head, fast = head.next;
			Stack<ListNode> stack = new Stack<ListNode>();

			while (fast != null && fast.next != null)
			{
				stack.Push(slow);
				slow = slow.next;
				fast = fast.next.next;
			}

			if (fast != null)
				stack.Push(slow);

			if (slow != null)
				slow = slow.next;

			while (slow != null)
			{
				if (slow.val != stack.Pop().val)
					return false;
				slow = slow.next;
			}
			return true;
		}
	}

	class PalindromeLinkedList_Solution3
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null || head.next == null)
				return true;

			ListNode slow = head, fast = head.next;

			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}

			ListNode tail = Reverse(slow);

			while (head != tail && head.next != tail)
			{
				if (head.val != tail.val)
					return false;
				head = head.next;
				tail = tail.next;
			}
			return head.next == tail ? head.val == tail.val : true;
		}

		private ListNode Reverse(ListNode preHead)
		{
			if (preHead == null || preHead.next == null)
				return null;

			ListNode pre = preHead, cur = preHead.next;
			while (cur != null)
			{
				ListNode next = cur.next;
				cur.next = pre;
				pre = cur;
				cur = next;
			}
			return pre;
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

		//static void Main()
		//{
		//	ListNode head = CreateLinkedList(new int[] { 1, 2, 1 });
		//	bool aa = new PalindromeLinkedList_Solution3().IsPalindrome(head);
		//}
	}
}

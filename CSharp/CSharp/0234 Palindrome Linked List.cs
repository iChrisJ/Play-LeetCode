using System.Collections.Generic;

namespace LeetCodeInCS._0234_Palindrome_Linked_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null || head.next == null)
				return true;

			ListNode mid = head, end = head;

			while (end != null && end.next != null)
			{
				mid = mid.next;
				end = end.next.next;
			}

			if (end != null)
				mid = mid.next;

			// reverse the right part LinkedList.
			ListNode pre = null;
			while (mid != null)
			{
				ListNode next = mid.next;
				mid.next = pre;
				pre = mid;
				mid = next;
			}

			end = head;
			while (end != null && pre != null)
			{
				if (end.val != pre.val)
					return false;
				pre = pre.next;
				end = end.next;
			}
			return true;
		}
	}

	public class Solution2
	{
		public bool IsPalindrome(ListNode head)
		{
			if (head == null || head.next == null)
				return true;

			ListNode behind = head, front = head;
			while (front != null && front.next != null)
			{
				behind = behind.next;
				front = front.next.next;
			}

			front = front == null ? behind : behind.next;

			Stack<ListNode> stack = new Stack<ListNode>();
			while (front != null)
			{
				stack.Push(front);
				front = front.next;
			}

			while (stack.Count > 0)
			{
				if (head.val != stack.Pop().val)
					return false;
				head = head.next;
			}
			return true;
		}
	}
}

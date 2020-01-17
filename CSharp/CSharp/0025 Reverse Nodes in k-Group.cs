using System.Collections.Generic;

namespace LeetCodeInCS._0025_Reverse_Nodes_in_k_Group
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode ReverseKGroup(ListNode head, int k)
		{
			if (head == null)
				return null;

			ListNode dummy = new ListNode(-1) { next = head };
			ListNode prev = dummy, cur = head;
			Stack<ListNode> stack = new Stack<ListNode>();

			while (cur != null)
			{
				stack.Push(cur);
				cur = cur.next;
				if (stack.Count == k)
				{
					while (stack.Count > 0)
					{
						prev.next = stack.Pop();
						prev = prev.next;
						//prev.next = null;
					}
					prev.next = cur;
				}
			}
			return dummy.next;
		}
	}

	public class Solution2
	{
		public ListNode ReverseKGroup(ListNode head, int k)
		{
			if (head == null)
				return null;

			ListNode dummy = new ListNode(-1) { next = head };
			ListNode pre_reverse = dummy, // The node before reverse group
				post_reverse = head; // The node after the reverse group
			int step = 0;

			while (post_reverse != null)
			{
				step++;
				post_reverse = post_reverse.next;
				if (step == k)
				{
					ListNode cur = pre_reverse.next;
					ListNode end_of_reversed = cur;
					ListNode prev = post_reverse;
					while (step > 0)
					{
						ListNode next = cur.next;
						cur.next = prev;
						prev = cur;
						cur = next;
						step--;
					}
					pre_reverse.next = prev;
					pre_reverse = end_of_reversed;
				}
			}
			return dummy.next;
		}
	}
}

using System.Collections.Generic;

namespace LeetCodeInCS._0445_Add_Two_Numbers_II
{
	/**
	 * Definition for singly-linked list.
	 */
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			Stack<ListNode> stack1 = new Stack<ListNode>();
			while (l1 != null)
			{
				stack1.Push(l1);
				l1 = l1.next;
			}

			Stack<ListNode> stack2 = new Stack<ListNode>();
			while (l2 != null)
			{
				stack2.Push(l2);
				l2 = l2.next;
			}

			Stack<ListNode> stack3 = new Stack<ListNode>();
			bool isCarried = false;
			while (stack1.Count != 0 || stack2.Count != 0)
			{
				int val = isCarried ? 1 : 0;
				if (stack1.Count == 0)
					val += stack2.Pop().val;
				else if (stack2.Count == 0)
					val += stack1.Pop().val;
				else
					val += stack1.Pop().val + stack2.Pop().val;

				isCarried = val / 10 == 1;
				val = val % 10;
				stack3.Push(new ListNode(val));
			}

			if (isCarried)
				stack3.Push(new ListNode(1));

			ListNode dummy = new ListNode(-1);
			ListNode prev = dummy;
			while (stack3.Count != 0)
			{
				prev.next = stack3.Pop();
				prev = prev.next;
			}
			return dummy.next;
		}
	}
}

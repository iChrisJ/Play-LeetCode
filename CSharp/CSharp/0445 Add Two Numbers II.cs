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

			bool isPreOverNine = false;
			Stack<ListNode> stack3 = new Stack<ListNode>();
			while (stack1.Count != 0 || stack2.Count != 0)
			{
				if (stack1.Count == 0)
				{
					ListNode node2 = stack2.Pop();
					if (isPreOverNine == false)
					{
						stack3.Push(new ListNode(node2.val));
					}
					else
					{
						isPreOverNine = (node2.val + 1) / 10 > 0;
						stack3.Push(new ListNode((node2.val + 1) % 10));
					}
				}
				else if (stack2.Count == 0)
				{
					ListNode node1 = stack1.Pop();
					if (isPreOverNine == false)
					{
						stack3.Push(new ListNode(node1.val));
					}
					else
					{
						isPreOverNine = (node1.val + 1) / 10 > 0;
						stack3.Push(new ListNode((node1.val + 1) % 10));
					}
				}
				else
				{
					ListNode node1 = stack1.Pop();
					ListNode node2 = stack2.Pop();
					if (isPreOverNine == false)
					{
						isPreOverNine = (node1.val + node2.val) / 10 > 0;
						stack3.Push(new ListNode((node1.val + node2.val) % 10));
					}
					else
					{
						isPreOverNine = (node1.val + node2.val + 1) / 10 > 0;
						stack3.Push(new ListNode((node1.val + node2.val + 1) % 10));
					}
				}
			}

			if (isPreOverNine == true)
				stack3.Push(new ListNode(1));

			ListNode reshead = new ListNode(0);
			ListNode cur = reshead;

			while (stack3.Count != 0)
			{
				cur.next = stack3.Pop();
				cur = cur.next;
			}

			return reshead.next;
		}
	}
}

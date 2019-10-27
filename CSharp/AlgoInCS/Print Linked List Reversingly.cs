using System;
using System.Collections.Generic;

/// <summary>
/// 从尾到头打印链表
/// 题目：输入一个链表的头结点，从尾到头反过来打印出每个结点的值。
/// </summary>
namespace AlgoInCS.Print_Linked_List_Reversingly
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	class Solution
	{
		public void PrintLinkedListReversingly(ListNode head)
		{
			if (head == null)
				return;

			Stack<ListNode> stack = new Stack<ListNode>();

			for (ListNode cur = head; cur != null; cur = cur.next)
				stack.Push(cur);

			while (stack.Count != 0)
			{
				ListNode top = stack.Pop();
				Console.Write($"{top.val} ");
			}
		}
	}

	class Solution2
	{
		public void PrintLinkedListReversingly(ListNode head)
		{
			if (head == null)
				return;

			PrintLinkedListReversingly(head.next);
			Console.Write($"{head.val} ");
		}

		//static void Main()
		//{
		//	ListNode head = new ListNode(1)
		//	{
		//		next = new ListNode(2)
		//		{
		//			next = new ListNode(3)
		//			{
		//				next = new ListNode(4)
		//				{
		//					next = new ListNode(5)
		//				}
		//			}
		//		}
		//	};

		//	new Solution().PrintLinkedListReversingly(null);
		//}
	}
}

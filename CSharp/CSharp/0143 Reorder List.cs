using System.Collections.Generic;

namespace LeetCodeInCS._0143_Reorder_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public void ReorderList(ListNode head)
		{
			if (head == null || head.next == null)
				return;

			ListNode cur = head;
			ListNode next = head.next;
			Stack<ListNode> stack = new Stack<ListNode>();
			while (next != null && next.next != null)
			{
				cur = cur.next;
				next = next.next.next;
			}

			if (cur != null) // Set cur as the head of the second half of linked list
			{
				next = cur.next;
				cur.next = null; // Set the next of the tail node of first half of linked list to NULL.
				cur = next;
			}
			while (cur != null)
			{
				stack.Push(cur);
				cur = cur.next;
			}

			cur = head;
			next = cur.next;
			while (stack.Count != 0)
			{
				ListNode top = stack.Pop();
				cur.next = top;
				top.next = next;
				cur = next;
				next = stack.Count == 0 ? null : next.next;
			}
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
		//	ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
		//	new Solution().ReorderList(head);
		//}
	}
}

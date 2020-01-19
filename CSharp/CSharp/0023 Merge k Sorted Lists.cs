using System.Collections.Generic;

namespace LeetCodeInCS._0023_Merge_k_Sorted_Lists
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode MergeKLists(ListNode[] lists)
		{
			if (lists == null || lists.Length == 0)
				return null;

			Queue<ListNode> queue = new Queue<ListNode>(lists);
			while (queue.Count > 1)
			{
				ListNode l1 = queue.Dequeue();
				ListNode l2 = queue.Dequeue();
				queue.Enqueue(Merge(l1, l2));
			}
			return queue.Peek();
		}

		private ListNode Merge(ListNode l1, ListNode l2)
		{
			ListNode dummy = new ListNode(-1);
			ListNode prev = dummy;

			while (l1 != null || l2 != null)
			{
				if (l1 == null)
				{
					prev.next = l2;
					break;
				}
				else if (l2 == null)
				{
					prev.next = l1;
					break;
				}
				else if (l1.val < l2.val)
				{
					prev.next = l1;
					l1 = l1.next;
				}
				else
				{
					prev.next = l2;
					l2 = l2.next;
				}
				prev = prev.next;
				prev.next = null;
			}
			return dummy.next;
		}
	}
}

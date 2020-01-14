namespace LeetCodeInCS._0092_Reverse_Linked_List_II
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
		public ListNode ReverseBetween(ListNode head, int m, int n)
		{
			if (head == null)
				return null;

			ListNode dummy = new ListNode(-1) { next = head };
			ListNode prev_reverse = dummy, cur = head;
			ListNode tail_reverse = null, prev = null;

			int pos = 1;
			while (pos <= n)
			{
				if (pos < m)
				{
					prev_reverse = cur;
					cur = cur.next;
				}
				else if (pos == m)
				{
					tail_reverse = cur;
					prev = cur;
					cur = cur.next;
				}
				else // i is (m, n] 
				{
					ListNode next = cur.next;
					cur.next = prev;
					prev = cur;
					cur = next;
				}
				pos++;
			}

			prev_reverse.next = prev;
			tail_reverse.next = cur;
			return dummy.next;

		}
	}
}

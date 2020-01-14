namespace LeetCodeInCS._0086_Partition_List
{
	/**
	 * Definition for singly-linked list.
	 **/
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode Partition(ListNode head, int x)
		{
			if (head == null)
				return null;

			ListNode gt_head = new ListNode(-1), lt_head = new ListNode(-1);
			ListNode gt_prev = gt_head, lt_prev = lt_head;
			ListNode cur = head;

			while (cur != null)
			{
				if (cur.val >= x)
				{
					gt_prev.next = cur;
					gt_prev = gt_prev.next;
					cur = cur.next;
					gt_prev.next = null;
				}
				else
				{
					lt_prev.next = cur;
					lt_prev = lt_prev.next;
					cur = cur.next;
					lt_prev.next = null;
				}
			}

			lt_prev.next = gt_head.next;
			return lt_head.next;
		}
	}
}

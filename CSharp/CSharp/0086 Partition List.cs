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
			ListNode lHead = new ListNode(0), rHead = new ListNode(0), lCur = lHead, rCur = rHead, cur = head;

			while (cur != null)
			{
				ListNode next = cur.next;
				if (cur.val < x)
				{
					lCur.next = cur;
					lCur = lCur.next;
					lCur.next = null;
				}
				else // cur.val >= x
				{
					rCur.next = cur;
					rCur = rCur.next;
					rCur.next = null;
				}
				cur = cur.next;
			}
			lCur.next = rHead.next;
			return lHead.next;
		}
	}
}

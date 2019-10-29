namespace LeetCodeInCS._0083_Remove_Duplicates_from_Sorted_List
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
		public ListNode DeleteDuplicates(ListNode head)
		{
			if (head == null)
				return head;

			ListNode cur = head;

			while (cur.next != null)
			{
				if (cur.val == cur.next.val)
				{
					ListNode temp = cur.next;
					cur.next = cur.next.next;
					temp.next = null;
				}
				else
					cur = cur.next;
			}
			return head;
		}
	}
}

namespace LeetCodeInCS._0147_Insertion_Sort_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode InsertionSortList(ListNode head)
		{
			if (head == null || head.next == null)
				return head;

			ListNode dummy = new ListNode(-1) { next = head };
			ListNode post_insert = head.next;
			head.next = null;
			while (post_insert != null)
			{
				ListNode insert = post_insert;
				post_insert = post_insert.next;

				ListNode prev = dummy, cur = dummy.next;
				while (cur != null)
				{
					if (cur.val > insert.val)
					{
						prev.next = insert;
						insert.next = cur;
						break;
					}
					prev = cur;
					cur = cur.next;
				}

				if (cur == null)
				{
					prev.next = insert;
					insert.next = null;
				}
			}
			return dummy.next;
		}
	}
}

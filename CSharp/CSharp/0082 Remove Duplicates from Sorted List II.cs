namespace CSharp._0082_Remove_Duplicates_from_Sorted_List_II
{
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
				return null;
			ListNode preHead = new ListNode(-1) { next = head }, cur = head, pre = preHead;

			while (cur.next != null)
			{
				if (cur.val != cur.next.val)
				{
					if (pre.next != cur)
						pre.next = cur.next;
					else
						pre = cur;
				}
				cur = cur.next;
			}
			if (pre.next != cur)
				pre.next = null;
			return preHead.next;
		}
	}
}

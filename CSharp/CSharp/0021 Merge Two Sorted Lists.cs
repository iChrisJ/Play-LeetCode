namespace LeetCodeInCS._0021_Merge_Two_Sorted_Lists
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode MergeTwoLists(ListNode l1, ListNode l2)
		{
			ListNode preHead = new ListNode(0);
			ListNode pre = preHead;

			while (l1 != null && l2 != null)
			{
				if (l1.val > l2.val)
				{
					pre.next = l2;
					l2 = l2.next;
				}
				else
				{
					pre.next = l1;
					l1 = l1.next;
				}
				pre = pre.next;
				pre.next = null;
			}
			if (l1 != null)
				pre.next = l1;
			if (l2 != null)
				pre.next = l2;
			return preHead.next;
		}
	}
}

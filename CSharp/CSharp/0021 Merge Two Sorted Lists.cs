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

	public class Solution2
	{
		public ListNode MergeTwoLists(ListNode l1, ListNode l2)
		{
			if (l1 == null)
				return l2;
			else if (l2 == null)
				return l1;
			else if (l1.val < l2.val)
			{
				l1.next = MergeTwoLists(l1.next, l2);
				return l1;
			}
			else
			{
				l2.next = MergeTwoLists(l1, l2.next);
				return l2;
			}
		}
	}
}

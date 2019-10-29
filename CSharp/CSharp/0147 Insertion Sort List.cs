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
			ListNode preHead = new ListNode(0) { next = head };
			ListNode cur = head.next;
			ListNode pre = head;

			while (cur != null)
			{
				ListNode sortedCur = preHead.next;
				ListNode sortedPre = preHead;
				ListNode next = cur.next;
				while (sortedCur != cur)
				{
					if (sortedCur.val > cur.val)
					{
						sortedPre.next = cur;
						cur.next = sortedCur;
						pre.next = next;
						break;
					}
					else
					{
						sortedPre = sortedCur;
						sortedCur = sortedCur.next;
					}
				}

				if (sortedCur == cur)
					pre = cur;
				cur = next;
			}
			return preHead.next;
		}
	}
}

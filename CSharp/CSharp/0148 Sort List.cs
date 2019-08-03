namespace CSharp._0148_Sort_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode SortList(ListNode head)
		{
			if (head == null || head.next == null)
				return head;

			ListNode slow = head;
			ListNode fast = head.next;

			while (fast != null && fast.next != null)
			{
				slow = slow.next;
				fast = fast.next.next;
			}

			ListNode head2 = slow.next;
			slow.next = null;
			head = SortList(head);
			head2 = SortList(head2);
			return merge(head, head2);
		}

		ListNode merge(ListNode l1, ListNode l2)
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

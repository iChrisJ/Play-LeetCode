namespace CSharp._0092_Reverse_Linked_List_II
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
		// TODO;
		public ListNode ReverseBetween(ListNode head, int m, int n)
		{
			ListNode preHead = new ListNode(0) { next = head };

			ListNode pre = preHead;

			for (int i = 1; i < m; i++)
				pre = pre.next;

			ListNode tail = pre.next;
			ListNode left = tail;

			pre.next = Reverse(pre.next, n - m, left);

			if (left != tail) tail.next = left;

			return preHead.next;
		}

		private ListNode Reverse(ListNode node, int length, ListNode left)
		{
			if (node == null || node.next == null || length == 0)
				return node;

			ListNode pre = node, cur = node.next;

			while (length > 0)
			{
				ListNode next = cur.next;
				cur.next = pre;
				pre = cur;
				cur = next;
				length--;
			}
			left = cur;
			return pre;
		}
	}
}

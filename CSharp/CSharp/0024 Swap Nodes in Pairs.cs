namespace LeetCodeInCS._0024_Swap_Nodes_in_Pairs
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode SwapPairs(ListNode head)
		{
			if (head == null || head.next == null)
				return head;
			ListNode preHead = new ListNode(0) { next = head };
			ListNode pre = preHead, cur = head;

			while (cur != null && cur.next != null)
			{
				ListNode next = cur.next;
				pre.next = next;
				cur.next = next.next;
				next.next = cur;

				pre = cur;
				cur = cur.next;
			}

			return preHead.next;
		}
	}

	public class Solution2
	{
		public ListNode SwapPairs(ListNode head)
		{
			if (head == null || head.next == null)
				return head;
			return Swap(head);
		}

		private ListNode Swap(ListNode node)
		{
			if (node == null || node.next == null)
				return node;

			ListNode next_pair_head = Swap(node.next.next);
			ListNode next = node.next;
			next.next = node;
			node.next = next_pair_head;
			return next;
		}
	}
}

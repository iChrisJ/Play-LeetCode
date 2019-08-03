namespace CSharp._0024_Swap_Nodes_in_Pairs
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
}

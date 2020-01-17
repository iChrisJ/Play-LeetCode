namespace LeetCodeInCS._0061_Rotate_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode RotateRight(ListNode head, int k)
		{
			if (head == null || head.next == null)
				return head;

			ListNode prev = head;
			int len = 1;

			while (prev.next != null)
			{
				len++;
				prev = prev.next;
			}
			prev.next = head;

			k = k % len;
			k = len - k;
			while (k > 0)
			{
				prev = prev.next;
				k--;
			}

			ListNode res = prev.next;
			prev.next = null;
			return res;
		}
	}
}

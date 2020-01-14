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

			int len = 0;
			ListNode cur = head;
			ListNode pre = null;
			while (cur != null)
			{
				len++;
				pre = cur;
				cur = cur.next;
			}

			pre.next = head;
			cur = head;

			k = k % len;
			k = len - k;
			while (k > 0)
			{
				pre = cur;
				cur = cur.next;
				k--;
			}

			pre.next = null;
			return cur;
		}
	}
}

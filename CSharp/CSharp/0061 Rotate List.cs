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

			int listLength = 1;
			ListNode dump = head;
			while (dump.next != null)
			{
				dump = dump.next;
				listLength++;
			}

			dump.next = head;
			int step = listLength - k % listLength;

			while (step != 1)
			{
				head = head.next;
				step--;
			}

			ListNode ret = head.next;
			head.next = null;
			return ret;
		}
	}
}

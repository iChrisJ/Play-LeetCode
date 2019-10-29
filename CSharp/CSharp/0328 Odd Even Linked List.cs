namespace LeetCodeInCS._0328_Odd_Even_Linked_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode OddEvenList(ListNode head)
		{
			if (head == null || head.next == null)
				return head;

			ListNode odd = head, even = head.next;
			ListNode oddCur = odd, evenCur = even;
			while (oddCur != null && evenCur != null)
			{
				ListNode next = evenCur.next;
				if (next != null)
				{
					oddCur.next = next;
					evenCur.next = next.next;
					oddCur = oddCur.next;
					evenCur = evenCur.next;
				}
				else
					break;
			}
			oddCur.next = even;
			return odd;
		}
	}
}

namespace CSharp._0203_Remove_Linked_List_Elements
{
	public class Solution
	{
		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public ListNode RemoveElements(ListNode head, int val)
		{
			if (head == null)
				return null;
			ListNode preHead = new ListNode(0) { next = head };
			ListNode cur = preHead;

			while (cur.next != null)
			{
				if (cur.next.val == val)
				{
					ListNode temp = cur.next;
					cur.next = cur.next.next;
					temp.next = null;
				}
				else
					cur = cur.next;
			}
			return preHead.next;
		}
	}
}

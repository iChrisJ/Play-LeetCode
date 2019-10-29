namespace LeetCodeInCS._0206_Reverse_Linked_List
{
	/**
	* Definition for singly-linked list.
	**/
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public ListNode ReverseList(ListNode head)
		{
			if (head == null)
				return head;
			ListNode pre = null, cur = head, next = head.next;

			while (next != null)
			{
				cur.next = pre;
				pre = cur;
				cur = next;
				next = next.next;
			}
			cur.next = pre;
			return cur;
		}
	}
}

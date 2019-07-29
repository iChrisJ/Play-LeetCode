namespace CSharp._0019_Remove_Nth_Node_From_End_of_List
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
		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			ListNode dump = new ListNode(0) { next = head };
			ListNode p = dump, q = dump;
			for (int i = 0; i < n + 1; i++)
			{
				if (q == null)
					throw new System.Exception("Invalid parameter n.");
				else
					q = q.next;
			}

			while (q != null)
			{
				p = p.next; // Move the p to the prior node of the deleting node
				q = q.next; // Mode q to the end of the linked list.
			}

			p.next = p.next.next;
			return dump.next;
		}
	}
}

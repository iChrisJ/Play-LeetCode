namespace CSharp._0237_Delete_Node_in_a_Linked_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class Solution
	{
		public void DeleteNode(ListNode node)
		{
			if (node == null)
				return;

			if (node.next == null)
				node = null;
				node = null;

			ListNode next = node.next;
			node.val = next.val;
			node.next = next.next;
			next.next = null;
		}
	}
}

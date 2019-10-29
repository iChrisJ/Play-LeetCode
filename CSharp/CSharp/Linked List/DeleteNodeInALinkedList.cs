namespace LeetCodeInCS.Linked_List
{
	/// <summary>
	/// 给定一个链表中的节点node，但不给定整个链表的头节点。如何在链表中删除node? 要求时间复杂度为O(1)
	/// </summary>
	class DeleteNodeInALinkedList_Solution
	{
		public void DeleteNode(ListNode node)
		{
			if (node == null)
				return;

			ListNode next = node.next;
			if (next == null)
			{
				node = null;
				return;
			}

			node.val = next.val;
			node.next = next.next;
			next = null;
		}
	}
}

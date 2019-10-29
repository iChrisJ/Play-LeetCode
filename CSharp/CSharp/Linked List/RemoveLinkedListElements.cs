namespace LeetCodeInCS.Linked_List
{
	/// <summary>
	/// 给定一个单链表的头节点head。链表中每个节点保存一个整数，再给定一个值val，把所有等于val的节点删掉。
	/// </summary>
	class RemoveLinkedListElements_Solution
	{
		public ListNode RemoveLinkedListElements(ListNode head, int val)
		{
			if (head == null)
				return null;

			ListNode dumpHead = new ListNode(-1) { next = head };
			ListNode cur = dumpHead;
			while (cur.next != null)
			{
				if (cur.next.val != val)
					cur = cur.next;
				else // cur.next.val == val
				{
					ListNode node = cur.next;
					cur.next = node.next;
					node.next = null;
				}
			}
			return dumpHead.next;
		}
	}
}

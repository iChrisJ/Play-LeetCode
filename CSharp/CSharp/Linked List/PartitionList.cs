namespace CSharp.Linked_List
{
	/// <summary>
	/// 给定一个链表的头节点head，再给定一个数num，请把链表调整成节点值小于num的节点都放在链表的左边，
	/// 值等于num的节点都放在链表的中间，值大于num的节点，都放在链表的右边。
	/// </summary>
	class PartitionList_Solution
	{
		public ListNode Partition(ListNode head, int x)
		{
			ListNode lhead = new ListNode(-1), rhead = new ListNode(-1), mhead = new ListNode(-1);
			ListNode lcur = lhead, rcur = rhead, mcur = mhead, cur = head;
			while (cur != null)
			{
				ListNode next = cur.next;
				if (cur.val < x)
				{
					lcur.next = cur;
					lcur = lcur.next;
					lcur.next = null;
				}
				else if (cur.val > x)
				{
					rcur.next = cur;
					rcur = rcur.next;
					rcur.next = null;
				}
				else // cur.val == x;
				{
					mcur.next = cur;
					mcur = mcur.next;
					mcur.next = null;
				}
				cur = next;
			}
			lcur.next = mhead.next;
			mcur.next = rhead.next;
			return lhead.next;
		}
	}
}

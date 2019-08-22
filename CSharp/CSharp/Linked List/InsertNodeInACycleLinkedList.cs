namespace CSharp.Linked_List
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}
	/// <summary>
	/// 给定一个整数num，如何在节点值有序的环形链表中插入个节点值为num的节点，并且保证这个环形单链表依然有序。
	/// </summary>
	class InsertNode_Solution
	{
		public ListNode InsertNode(ListNode head, int num)
		{
			ListNode node = new ListNode(num);
			if (head == null)
			{
				node.next = node;
				return node;
			}

			ListNode cur = head.next, prev = head;

			while (cur != head)
			{
				if (cur.val >= num && prev.val <= num)
					break;
				prev = cur;
				cur = cur.next;
			}
			node.next = cur;
			prev.next = node;
			return num < head.val ? node : head;
		}
	}
}

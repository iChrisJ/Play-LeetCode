using System;

namespace CSharp.Linked_List
{
	/// <summary>
	/// 给定两个有序链表的头节点head1和head2, 打印两个有序链表的公共部分.
	/// </summary>
	class PrintCommonPartOfTwoLinkedList_Solution
	{
		public void PrintCommonPart(ListNode head1, ListNode head2)
		{
			if (head1 == null || head2 == null)
				return;

			ListNode cur1 = head1, cur2 = head2;
			while (cur1 != null || cur2 != null)
			{
				if (cur1.val < cur2.val)
					cur1 = cur1.next;
				else if (cur1.val > cur2.val)
					cur2 = cur2.next;
				else if (cur1.val == cur2.val)
				{
					Console.Write($"{cur1.val} -> ");
					cur1 = cur1.next;
					cur2 = cur2.next;
				}
			}
		}
	}
}

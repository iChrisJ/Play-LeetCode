namespace CSharp.Linked_List
{
	/// <summary>
	/// 如何判断两个无环单链表是否相交? 相交的话返回第一个相交的节点, 不想交的话返回. 
	/// 如果两个链表长度分别为N和M, 请做到时间复杂度O(N+M), 额外空间复杂度O(1)
	/// </summary>
	class IntersectionOfTwoLinkedLists_Solution
	{
		public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			int lenA = GetLinkedListLength(headA);
			int lenB = GetLinkedListLength(headB);

			if (lenA == 0 || lenB == 0)
				return null;
			else if (lenA > lenB)
			{
				while (lenA > lenB)
				{
					headA = headA.next;
					lenA--;
				}
			}
			else if (lenA < lenB)
			{
				while (lenA < lenB)
				{
					headB = headB.next;
					lenB--;
				}
			}

			while (headA != null && headA != headB)
			{
				headA = headA.next;
				headB = headB.next;
			}
			return headA == null ? null : headA;
		}

		private int GetLinkedListLength(ListNode head)
		{
			int length = 0;
			while (head != null)
			{
				length++;
				head = head.next;
			}
			return length;
		}
	}
}

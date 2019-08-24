namespace CSharp.Linked_List
{
	/// <summary>
	/// 如何判断两个有环单链表是否相交? 相交的话返回第一个相交的节点, 不想交的话返回空. 
	/// 如果两个链表长度分别为N和M，请做到时间复杂度O(N+M), 额外空间复杂度O(1)
	/// </summary>
	class IntersectionOfTwoCycleLinkedLists_Solution
	{
		public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
		{
			if (headA == null || headB == null)
				return null;

			ListNode intersecNodeA = new LinkedListCycle_Solution().DetectCycle(headA);
			ListNode intersecNodeB = new LinkedListCycle_Solution().DetectCycle(headB);

			if (intersecNodeA == intersecNodeB)
			{
				int lenA = GetCycleLinkedListLength(headA, intersecNodeA);
				int lenB = GetCycleLinkedListLength(headB, intersecNodeB);
				if (lenA == 0 || lenB == 0)
					return intersecNodeA;
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

				while (headA != headB)
				{
					headA = headA.next;
					headB = headB.next;
				}
				return headA == intersecNodeA ? intersecNodeA : headA;
			}
			else
			{
				ListNode cur = intersecNodeA;
				while (cur != intersecNodeB)
				{
					cur = cur.next;
					if (cur == intersecNodeA)
						return null;
				}
				return intersecNodeA;
			}
		}

		private int GetCycleLinkedListLength(ListNode head, ListNode intersection)
		{
			int length = 0;
			while (head != intersection)
			{
				length++;
				head = head.next;
			}
			return length;
		}
	}
}

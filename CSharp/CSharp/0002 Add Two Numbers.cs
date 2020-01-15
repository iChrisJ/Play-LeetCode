namespace LeetCodeInCS._0002_Add_Two_Numbers
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

	/// <summary>
	/// 迭代
	/// </summary>
	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			if (l1 == null)
				return l2;

			if (l2 == null)
				return l1;

			ListNode cur1 = l1, cur2 = l2;
			ListNode dummy = new ListNode(0);
			ListNode prev = dummy;
			bool isCarried = false;
			while (cur1 != null || cur2 != null)
			{
				int val = isCarried ? 1 : 0;

				if (cur1 == null)
				{
					val += cur2.val;
					cur2 = cur2.next;
				}
				else if (cur2 == null)
				{
					val += cur1.val;
					cur1 = cur1.next;
				}
				else
				{
					val += cur1.val + cur2.val;
					cur1 = cur1.next;
					cur2 = cur2.next;
				}

				ListNode newNode = new ListNode(val % 10);
				isCarried = val / 10 == 1;
				prev.next = newNode;
				prev = prev.next;
			}

			if (isCarried)
			{
				ListNode newNode = new ListNode(1);
				prev.next = newNode;
			}
			return dummy.next;
		}
	}

	/// <summary>
	/// 递归
	/// </summary>
	public class Solution2
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			return AddTwoNumbers(l1, l2, false);
		}

		public ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool isCarried)
		{
			if (l1 == null && l2 == null)
				return isCarried ? new ListNode(1) : null;

			int val = (isCarried ? 1 : 0);
			if (l1 == null)
				val += l2.val;
			else if (l2 == null)
				val += l1.val;
			else
				val += l1.val + l2.val;

			isCarried = val >= 10;
			val = val % 10;

			ListNode res = new ListNode(val)
			{
				next = AddTwoNumbers((l1 == null ? null : l1.next), (l2 == null ? null : l2.next), isCarried)
			};
			return res;
		}
	}
}
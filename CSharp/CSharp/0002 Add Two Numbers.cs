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

	public class Solution
	{
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			ListNode preRes = new ListNode(0);
			ListNode cur = preRes;
			bool isPreOverNine = false;
			while (l1 != null || l2 != null)
			{
				if (l1 == null)
				{
					if (isPreOverNine == false)
					{
						cur.next = new ListNode(l2.val);
					}
					else
					{
						isPreOverNine = (l2.val + 1) / 10 > 0;
						cur.next = new ListNode((l2.val + 1) % 10);
					}
					l2 = l2.next;
				}
				else if (l2 == null)
				{
					if (isPreOverNine == false)
					{
						cur.next = new ListNode(l1.val);
					}
					else
					{
						isPreOverNine = (l1.val + 1) / 10 > 0;
						cur.next = new ListNode((l1.val + 1) % 10);
					}
					l1 = l1.next;
				}
				else
				{
					if (isPreOverNine == false)
					{
						isPreOverNine = (l1.val + l2.val) / 10 > 0;
						cur.next = new ListNode((l1.val + l2.val) % 10);
					}
					else
					{
						isPreOverNine = (l1.val + l2.val + 1) / 10 > 0;
						cur.next = new ListNode((l1.val + l2.val + 1) % 10);
					}

					l1 = l1.next;
					l2 = l2.next;
				}

				cur = cur.next;
			}
			if (isPreOverNine == true)
				cur.next = new ListNode(1);
			return preRes.next;
		}
	}
}
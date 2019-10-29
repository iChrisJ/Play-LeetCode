using System;
using System.Collections.Generic;

namespace LeetCodeInCS.Linked_List
{
	/// <summary>
	/// 给定一个单链表的头节点head，实现一个调整单链表的函数，使得每K个节点之间逆序，如果最后不够K个节点一组，则不调整最后几个节点。
	/// 例如链表
	/// 1->2->3->4->5->6->7->8->null，K=3
	/// 调整后为
	/// 3->2->1->6->5->4->7->8->null
	/// 因为K==3，所以每三个节点之间逆序，但其中的7，8不调整，因为只有两个节点不够一组。
	/// </summary>
	class ReverseNodesInKGroup_Solution
	{
		public ListNode ReverseNodesInKGroup(ListNode head, int k)
		{
			if (head == null || head.next == null || k < 2)
				return head;

			ListNode dumpHead = new ListNode(-1) { next = head };
			Stack<ListNode> stack = new Stack<ListNode>(k);
			ListNode cur = head, prev = dumpHead;

			while (cur != null)
			{
				while (stack.Count != k && cur != null)
				{
					stack.Push(cur);
					cur = cur.next;
				}

				if (stack.Count != k && cur == null)
					return dumpHead.next;

				while (stack.Count != 0)
				{
					ListNode node = stack.Pop();
					prev.next = node;
					prev = prev.next;
					prev.next = null;
				}
				prev.next = cur;
			}
			return dumpHead.next;
		}
	}

	class ReverseNodesInKGroup_Solution2
	{
		public ListNode ReverseNodesInKGroup(ListNode head, int k)
		{
			if (head == null || head.next == null || k < 2)
				return head;

			ListNode dumpHead = new ListNode(-1) { next = head };

			ListNode tailOfPre = dumpHead; // The last node of previous group.
			ListNode cur = head; // The current node in current group.
			ListNode headOfNext = head; // The first node of next group

			while (headOfNext != null)
			{
				int time = 0;
				ListNode headOfCur = null;
				while (time < k && headOfNext != null)
				{
					if (time == k - 1)
						headOfCur = headOfNext;

					headOfNext = headOfNext.next;
					time++;
				}

				if (time != k)
					break;

				ListNode tailOfCur = cur;
				ListNode next = cur.next;
				ListNode prev = headOfNext;

				tailOfPre.next = headOfCur;

				while (time > 0)
				{
					cur.next = prev;
					prev = cur;
					cur = next;
					if (next != null)
						next = next.next;
					else
						break;
					time--;
				}

				tailOfPre = tailOfCur;
			}

			return dumpHead.next;
		}

		public static ListNode CreateLinkedList(int[] arr)
		{
			if (arr.Length == 0)
				return null;

			ListNode head = new ListNode(arr[0]);
			ListNode curNode = head;
			for (int i = 1; i < arr.Length; i++)
			{
				curNode.next = new ListNode(arr[i]);
				curNode = curNode.next;
			}
			return head;
		}

		public static void PrintLinkedList(ListNode head)
		{

			ListNode curNode = head;
			while (curNode != null)
			{
				Console.Write($"{curNode.val} -> ");
				curNode = curNode.next;
			}
			Console.Write("null");
		}

		//static void Main()
		//{
		//	ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
		//	head = new ReverseNodesInKGroup_Solution2().ReverseNodesInKGroup(head, 2);
		//	PrintLinkedList(head);
		//}
	}
}

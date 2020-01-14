using System.Collections.Generic;

namespace LeetCodeInCS._0430_Flatten_a_Multilevel_Doubly_Linked_List
{
	// Definition for a Node.
	public class Node
	{
		public int val;
		public Node prev;
		public Node next;
		public Node child;

		public Node() { }
		public Node(int _val, Node _prev, Node _next, Node _child)
		{
			val = _val;
			prev = _prev;
			next = _next;
			child = _child;
		}

		public class Solution
		{
			public Node Flatten(Node head)
			{
				if (head == null)
					return null;

				Node cur = head;
				Stack<Node> stack = new Stack<Node>();

				while (cur != null)
				{
					if (cur.child != null)
					{
						if (cur.next != null)
							stack.Push(cur.next);

						cur.next = cur.child;
						cur.next.prev = cur;
						cur.child = null;
					}
					else if (cur.next == null && stack.Count != 0)
					{
						Node top = stack.Peek();
						cur.next = top;
						top.prev = cur;
					}

					cur = cur.next;
				}

				return head;
			}
		}

		public class Solution2
		{
			public Node Flatten(Node head)
			{
				if (head == null)
					return head;

				Node cur = head;
				Stack<Node> stack = new Stack<Node>();

				while (cur.next != null || cur.child != null || stack.Count != 0)
				{
					if (cur.child != null)
					{
						if (cur.next != null)
							stack.Push(cur.next);
						Node child = cur.child;
						cur.child = null;
						cur.next = child;
						child.prev = cur;
					}
					else if (cur.next != null) { }
					else //stack.Count != 0
					{
						Node top = stack.Pop();
						cur.next = top;
						top.prev = cur;
					}
					cur = cur.next;
				}
				return head;
			}
		}
	}
}
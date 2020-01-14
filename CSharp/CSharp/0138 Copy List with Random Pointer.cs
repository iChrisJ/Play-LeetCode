using System.Collections.Generic;

namespace LeetCodeInCS._0138_Copy_List_with_Random_Pointer
{
	public class Node
	{
		public int val;
		public Node next;
		public Node random;

		public Node(int _val)
		{
			val = _val;
			next = null;
			random = null;
		}

		public Node() { }
		public Node(int _val, Node _next, Node _random)
		{
			val = _val;
			next = _next;
			random = _random;
		}
	}

	public class Solution
	{
		public Node CopyRandomList(Node head)
		{
			if (head == null)
				return null;

			Node cur = head;
			Dictionary<Node, Node> map = new Dictionary<Node, Node>();
			while (cur != null)
			{
				Node node = new Node(cur.val, null, null);
				map.Add(cur, node);
				cur = cur.next;
			}

			cur = head;
			Node res = new Node();
			Node pre = res;
			while (cur != null)
			{
				Node node = map[cur];
				node.next = cur.next == null ? null : map[cur.next];
				node.random = cur.random == null ? null : map[cur.random];

				pre.next = node;
				cur = cur.next;
				pre = pre.next;
			}
			return res.next;
		}
	}

	public class Solution2
	{
		public Node CopyRandomList(Node head)
		{
			if (head == null)
				return null;

			Node cur = head;
			while (cur != null)
			{
				Node cloneNode = new Node(cur.val) { next = cur.next };
				cur.next = cloneNode;
				cur = cloneNode.next;
			}

			cur = head;
			while (cur != null && cur.next != null)
			{
				if (cur.random != null)
					cur.next.random = cur.random.next;
				cur = cur.next.next;
			}

			cur = head;
			Node dummy = new Node(-1) { next = head };
			Node pre = dummy;
			Node cloneDummy = new Node(-1);
			Node clonePre = cloneDummy;
			bool isCloned = false;

			while (cur != null)
			{
				if (isCloned)
				{
					clonePre.next = cur;
					cur = cur.next;
					pre.next = cur;
					clonePre = clonePre.next;
					clonePre.next = null;
				}
				else
				{
					pre = cur;
					cur = cur.next;
				}
				isCloned = !isCloned;
			}
			return cloneDummy.next;
		}
	}
}

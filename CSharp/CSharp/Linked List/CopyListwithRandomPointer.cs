using System.Collections.Generic;

namespace CSharp.Linked_List
{
	public class Node
	{
		public int val;
		public Node next;
		public Node random;

		public Node() { }
		public Node(int _val, Node _next, Node _random)
		{
			val = _val;
			next = _next;
			random = _random;
		}
	}

	/// <summary>
	/// 一个链表结构中, 每个节点不仅含有一条指向下一个节点的next指针, 同时含有一条rand指针,
	/// rand指针可能指向任何一个链表中的节点, 请复制这种含有rnd指针节点的链表。
	/// </summary>
	class CopyListwithRandomPointer_Solution
	{
		public Node CopyRandomList(Node head)
		{
			if (head == null)
				return null;

			Node cur = head;
			while (cur != null)
			{
				Node node = new Node(cur.val, cur.next, null);
				cur.next = node;
				cur = node.next;
			}

			cur = head;
			Node res = new Node();
			Node resCur = res;
			while (cur != null)
			{
				Node node = cur.next;
				resCur.next = node;
				node.random = cur.random == null ? null : cur.random.next;
				cur = node.next;
				resCur = resCur.next;
			}
			return res.next;
		}
	}

	class CopyListwithRandomPointer_Solution2
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
}

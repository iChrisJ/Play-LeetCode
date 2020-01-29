using System.Collections.Generic;

namespace LeetCodeInCS._0116_Populating_Next_Right_Pointers_in_Each_Node
{
	// Definition for a Node.
	public class Node
	{
		public int val;
		public Node left;
		public Node right;
		public Node next;

		public Node() { }
		public Node(int _val, Node _left, Node _right, Node _next)
		{
			val = _val;
			left = _left;
			right = _right;
			next = _next;
		}
	}

	public class Solution
	{
		public Node Connect(Node root)
		{
			if (root == null || root.left == null)
				return root;

			root.left.next = root.right;

			if (root.next != null)
				root.right.next = root.next.left;

			Connect(root.left);
			Connect(root.right);
			return root;
		}
	}

	public class Solution2
	{
		public Node Connect(Node root)
		{
			if (root == null)
				return null;

			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				Node next = null;
				int len = queue.Count;
				while (len > 0)
				{
					Node front = queue.Dequeue();
					front.next = next;

					if (front.right != null) // ensure the right node is in the front of the left one.
						queue.Enqueue(front.right);
					if (front.left != null)
						queue.Enqueue(front.left);

					next = front;
					len--;
				}
			}
			return root;
		}
	}
}

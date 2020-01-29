namespace LeetCodeInCS._0117_Populating_Next_Right_Pointers_in_Each_Node_II
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
			if (root == null)
				return null;

			Node cousin = NextCousin(root);

			if (root.right != null)
				root.right.next = cousin;

			if (root.left != null)
				root.left.next = root.right ?? cousin;

			Connect(root.right); // Make sure the right node it traverse first.
			Connect(root.left);
			return root;
		}

		private Node NextCousin(Node node)
		{
			Node next = node.next;
			while (next != null)
			{
				if (next.left != null)
					return next.left;
				else if (next.right != null)
					return next.right;
				next = next.next;
			}
			return null;
		}
	}
}

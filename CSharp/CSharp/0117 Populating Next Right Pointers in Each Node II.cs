namespace CSharp._0117_Populating_Next_Right_Pointers_in_Each_Node_II
{
	// Definition for a Node.
	class Node
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

	class Solution
	{
		public Node Connect(Node root)
		{
			if (root == null)
				return root;

			Node curNext = root.next;
			Node cousin = null;

			while (curNext != null)
			{
				if (curNext.left != null)
				{
					cousin = curNext.left;
					break;
				}

				if (curNext.right != null)
				{
					cousin = curNext.right;
					break;
				}
				curNext = curNext.next;
			}

			if (root.left != null)
				root.left.next = root.right == null ? cousin : root.right;

			if (root.right != null)
				root.right.next = cousin;

			Connect(root.right); // Make sure the right node it traverse first.
			Connect(root.left);
			return root;
		}
	}
}

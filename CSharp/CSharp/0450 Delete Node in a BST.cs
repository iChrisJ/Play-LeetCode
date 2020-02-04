namespace LeetCodeInCS._0450_Delete_Node_in_a_BST
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		public TreeNode DeleteNode(TreeNode root, int key)
		{
			if (root == null)
				return null;

			if (root.val > key)
				root.left = DeleteNode(root.left, key);
			else if (root.val < key)
				root.right = DeleteNode(root.right, key);
			else // root.val == key
			{
				if (root.left == null)
					return root.right;
				else if (root.right == null)
					return root.left;
				else // root.left != null && root.right != null
				{
					TreeNode node = GetMinNode(root.right, root);
					node.left = root.left;
					node.right = root.right;
					return node;
				}
			}
			return root;
		}

		private TreeNode GetMinNode(TreeNode node, TreeNode parent)
		{
			if (node.left == null)
			{
				// if node.left == null, as the node is from right of the parent, 
				// so the right child of the node should be set the right of the parent.
				parent.right = node.right;
				return node;
			}

			while (node.left != null)
			{
				parent = node;
				node = node.left;
			}
			parent.left = node.right;
			return node;
		}
	}
}

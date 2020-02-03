using System.Collections.Generic;

namespace LeetCodeInCS._0226_Invert_Binary_Tree
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
		public TreeNode InvertTree(TreeNode root)
		{
			if (root == null)
				return root;

			TreeNode temp = root.left;
			root.left = root.right;
			root.right = temp;

			InvertTree(root.left);
			InvertTree(root.right);
			return root;
		}
	}

	/// <summary>
	/// BFS
	/// </summary>
	public class Solution2
	{
		public TreeNode InvertTree(TreeNode root)
		{
			if (root == null)
				return null;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				TreeNode frnt = queue.Dequeue();

				TreeNode tmp = frnt.left;
				frnt.left = frnt.right;
				frnt.right = tmp;

				if (frnt.left != null)
					queue.Enqueue(frnt.left);
				if (frnt.right != null)
					queue.Enqueue(frnt.right);
			}
			return root;
		}
	}
}

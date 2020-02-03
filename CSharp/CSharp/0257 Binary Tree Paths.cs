using System.Collections.Generic;

namespace LeetCodeInCS._0257_Binary_Tree_Paths
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
		public IList<string> BinaryTreePaths(TreeNode root)
		{
			IList<string> res = new List<string>();
			if (root == null)
				return res;

			if (root.left == null && root.right == null)
				res.Add($"{root.val}");

			BinaryTreePaths(root.left, $"{root.val}", res);
			BinaryTreePaths(root.right, $"{root.val}", res);
			return res;
		}

		private void BinaryTreePaths(TreeNode node, string path, IList<string> res)
		{
			if (node == null)
				return;

			path += $"->{node.val}";
			if (node.left == null && node.right == null)
			{
				res.Add(path); // No need to get a copy of the path, as string of the path is fixed.
				return;
			}

			BinaryTreePaths(node.left, path, res);
			BinaryTreePaths(node.right, path, res);
		}
	}
}

using System;

namespace LeetCodeInCS._1123_Lowest_Common_Ancestor_of_Deepest_Leaves
{
	// Definition for a binary tree node.
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		int max = -1;
		TreeNode lca = null;

		public TreeNode LcaDeepestLeaves(TreeNode root)
		{
			DFS(root, 0);
			return lca;
		}

		private int DFS(TreeNode node, int depth)
		{
			if (node == null)
				return depth - 1;

			int left = DFS(node.left, depth + 1);
			int right = DFS(node.right, depth + 1);

			if (depth > max)
				max = depth;

			if (left == max && right == max)
				lca = node;

			return Math.Max(left, right);
		}
	}
}

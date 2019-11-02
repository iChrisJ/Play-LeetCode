using System;

namespace LeetCodeInCS._1026_Maximum_Difference_Between_Node_and_Ancestor
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
		private int max = 0;
		public int MaxAncestorDiff(TreeNode root)
		{
			return root == null ? 0 : MaxAncestorDiff(root, root.val, root.val);
		}

		private int MaxAncestorDiff(TreeNode node, int maximum, int minimum)
		{
			maximum = Math.Max(maximum, node.val);
			minimum = Math.Min(minimum, node.val);

			int max = Math.Max(Math.Abs(maximum - node.val), Math.Abs(minimum - node.val));

			if (node.left != null)
				max = Math.Max(max, MaxAncestorDiff(node.left, maximum, minimum));

			if (node.right != null)
				max = Math.Max(max, MaxAncestorDiff(node.right, maximum, minimum));

			return max;
		}
	}
}

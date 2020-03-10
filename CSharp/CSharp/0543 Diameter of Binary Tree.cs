using System;

namespace LeetCodeInCS._0543_Diameter_of_Binary_Tree
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
		private int diameter = 0;
		public int DiameterOfBinaryTree(TreeNode root)
		{
			Depth(root);
			return diameter;
		}

		private int Depth(TreeNode node)
		{
			if (node == null)
				return 0;

			int left = Depth(node.left);
			int right = Depth(node.right);
			diameter = Math.Max(diameter, left + right);
			return Math.Max(left, right) + 1;
		}
	}
}

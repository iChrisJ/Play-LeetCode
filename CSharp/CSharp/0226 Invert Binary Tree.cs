﻿namespace LeetCodeInCS._0226_Invert_Binary_Tree
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
}

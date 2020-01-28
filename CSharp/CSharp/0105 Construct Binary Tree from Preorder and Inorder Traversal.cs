using System;

namespace LeetCodeInCS._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
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
		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
		}

		private TreeNode BuildTree(int[] preorder, int pre_l, int pre_r, int[] inorder, int in_l, int in_r)
		{
			if (pre_l > pre_r || in_l > in_r)
				return null;

			int val = preorder[pre_l];
			int pos = Array.IndexOf<int>(inorder, val, in_l);

			TreeNode node = new TreeNode(val);

			node.left = BuildTree(preorder, pre_l + 1, pre_l + (pos - in_l), inorder, in_l, pos - 1);
			node.right = BuildTree(preorder, pre_l + (pos - in_l) + 1, pre_r, inorder, pos + 1, in_r);

			return node;
		}
	}
}


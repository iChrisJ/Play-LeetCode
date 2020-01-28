using System;

namespace LeetCodeInCS._0106_Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
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
		public TreeNode BuildTree(int[] inorder, int[] postorder)
		{
			return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
		}

		private TreeNode BuildTree(int[] inorder, int in_l, int in_r, int[] postorder, int post_l, int post_r)
		{
			if (post_l > post_r || in_l > in_r)
				return null;

			int val = postorder[post_r];
			int pos = Array.IndexOf<int>(inorder, val, in_l);

			TreeNode node = new TreeNode(val);

			node.left = BuildTree(inorder, in_l, pos - 1, postorder, post_l, post_r - (in_r - pos) - 1);
			node.right = BuildTree(inorder, pos + 1, in_r, postorder, post_r - (in_r - pos), post_r - 1);

			return node;
		}
	}
}

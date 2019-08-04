using System;

namespace CSharp._0110_Balanced_Binary_Tree
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
		public bool IsBalanced(TreeNode root)
		{
			if (root == null)
				return true;
			return IsBalanced(root.left) && IsBalanced(root.right) && Math.Abs(MaxDepth(root.left) - MaxDepth(root.right)) <= 1;
		}

		public int MaxDepth(TreeNode node)
		{
			if (node == null)
				return 0;
			return 1 + Math.Max(MaxDepth(node.left), MaxDepth(node.right));
		}
	}
}

using System;

namespace CSharp._0111_Minimum_Depth_of_Binary_Tree
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
		public int MinDepth(TreeNode root)
		{
			if (root == null)
				return 0;
			int left = MinDepth(root.left);
			int right = MinDepth(root.right);
			return (left == 0 || right == 0) ? left + right + 1 : Math.Min(left, right) + 1;
		}
	}
}

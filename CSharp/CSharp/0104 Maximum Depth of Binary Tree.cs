using System;

namespace CSharp._0104_Maximum_Depth_of_Binary_Tree
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
		public int MaxDepth(TreeNode root)
		{
			if (root == null)
				return 0;
			return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
		}
	}
}

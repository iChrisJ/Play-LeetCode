using System;

namespace CSharp._0235_Lowest_Common_Ancestor_of_a_Binary_Search_Tree
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
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root.val >= Math.Min(p.val, q.val) && root.val <= Math.Max(p.val, q.val))
				return root;
			else if (root.val > Math.Max(p.val, q.val))
				return LowestCommonAncestor(root.left, p, q);
			else
				return LowestCommonAncestor(root.right, p, q);
		}
	}

	public class Solution2
	{
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			while (root != null)
			{
				if (root.val < Math.Min(p.val, q.val))
					root = root.right;
				else if (root.val > Math.Max(p.val, q.val))
					root = root.left;
				else
					return root;
			}
			return root;
		}
	}
}

using System;

namespace LeetCodeInCS._0235_Lowest_Common_Ancestor_of_a_Binary_Search_Tree
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
			if (root == null || p == null || q == null)
				return null;

			if (root.val < Math.Min(p.val, q.val))
				return LowestCommonAncestor(root.right, p, q);
			else if (root.val > Math.Max(p.val, q.val))
				return LowestCommonAncestor(root.left, p, q);
			else // p <= root <= q or q <= root <= p
				return root;
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

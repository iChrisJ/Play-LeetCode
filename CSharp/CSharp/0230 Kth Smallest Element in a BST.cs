using System;

namespace LeetCodeInCS._0230_Kth_Smallest_Element_in_a_BST
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
		private int? res;
		private int rank;
		public int KthSmallest(TreeNode root, int k)
		{
			res = null;
			rank = 0;
			InOrder(root, k);
			if (res == null)
				throw new InvalidOperationException("The k-th smallest node doesn't exist.");
			else
				return (int)res;
		}

		public void InOrder(TreeNode node, int k)
		{
			if (node == null)
				return;

			InOrder(node.left, k);
			if ((++rank) == k)
			{
				res = node.val;
				return;
			}
			InOrder(node.right, k);
		}
	}
}

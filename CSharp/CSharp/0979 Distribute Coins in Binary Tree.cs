using System;

namespace LeetCodeInCS._0979_Distribute_Coins_in_Binary_Tree
{
	/**
	* Definition for a binary tree node.
	* */
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		public int DistributeCoins(TreeNode root)
		{
			int aux = 0;
			Balance(root, ref aux);
			return aux;
		}

		private int Balance(TreeNode node, ref int aux)
		{
			if (node == null)
				return 0;

			int left = Balance(node.left, ref aux);
			int right = Balance(node.right, ref aux);
			aux += Math.Abs(left) + Math.Abs(right);
			return node.val - 1 + left + right;
		}
	}
}

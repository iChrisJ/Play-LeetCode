using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0337_House_Robber_III
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
		private Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();

		public int Rob(TreeNode root)
		{
			if (root == null)
				return 0;

			if (memo.ContainsKey(root))
				return memo[root];

			int take = root.val
				+ (root.left == null ? 0 : Rob(root.left.left) + Rob(root.left.right))
				+ (root.right == null ? 0 : Rob(root.right.left) + Rob(root.right.right));

			int leave = Rob(root.left) + Rob(root.right);

			int res = Math.Max(take, leave);
			memo.Add(root, res);
			return res;
		}
	}

	// DFS - POST Order
	public class Solution2
	{
		public int Rob(TreeNode root)
		{
			(int, int) res = RobHouse(root);
			return Math.Max(res.Item1, res.Item2);
		}

		/// <summary>
		/// DFS - Post Order
		/// </summary>
		/// <returns>(result if rob this hourse, result if not rob this house)</returns>
		public (int, int) RobHouse(TreeNode node)
		{
			if (node == null)
				return (0, 0);

			(int, int) left = RobHouse(node.left);
			(int, int) right = RobHouse(node.right);

			// If rob current house, then choose the result of not rob left and right child's houses.
			int rob = node.val + left.Item2 + right.Item2;

			// If not rob current house, it's OK to rob/not rob left and right child's houses,
			// need to choose the maximum value.
			int not_rob = Math.Max(left.Item1, left.Item2)
				+ Math.Max(right.Item1, right.Item2);

			return (rob, not_rob);
		}
	}
}

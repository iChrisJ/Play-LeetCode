using System.Collections.Generic;

namespace LeetCodeInCS._0113_Path_Sum_II
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
		public IList<IList<int>> PathSum(TreeNode root, int sum)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (root == null)
				return res;
			PathSum(root, sum, new List<int>(), res);
			return res;
		}

		private void PathSum(TreeNode node, int sum, IList<int> path, IList<IList<int>> res)
		{
			if (node == null)
				return;

			sum -= node.val;
			path.Add(node.val);

			if (node.left == null && node.right == null && sum == 0)
			{
				res.Add(path);
				return;
			}

			IList<int> right_path = new List<int>(path);
			PathSum(node.left, sum, path, res);
			PathSum(node.right, sum, right_path, res);
		}
	}
}

using System.Collections.Generic;

namespace CSharp._0113_Path_Sum_II
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
			if (root.left == null && root.right == null && root.val == sum)
			{
				res.Add(new List<int> { root.val });
				return res;
			}

			IList<IList<int>> leftArr = PathSum(root.left, sum - root.val);
			foreach (var left in leftArr)
			{
				left.Insert(0, root.val);
				res.Add(left);
			}

			IList<IList<int>> rightArr = PathSum(root.right, sum - root.val);
			foreach (var right in rightArr)
			{
				right.Insert(0, root.val);
				res.Add(right);
			}
			return res;
		}
	}
}

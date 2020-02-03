using System.Collections.Generic;

namespace LeetCodeInCS._0129_Sum_Root_to_Leaf_Numbers
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
		private int res;
		public int SumNumbers(TreeNode root)
		{
			res = 0;
			if (root == null)
				return res;

			Numbers_DFS(root, 0);
			return res;
		}

		public void Numbers_DFS(TreeNode node, int curNum)
		{
			if (node == null)
				return;

			curNum = curNum * 10 + node.val;

			if (node.left != null)
				Numbers_DFS(node.left, curNum);
			if (node.right != null)
				Numbers_DFS(node.right, curNum);
			if (node.left == null && node.right == null)
				res += curNum;
		}
	}

	public class Solution2
	{
		public int SumNumbers(TreeNode root)
		{
			int sum = 0;
			if (root == null)
				return sum;

			IList<int> nums = new List<int>();
			SumNumbers(root, string.Empty, nums);
			foreach (int num in nums)
				sum += num;
			return sum;
		}

		private void SumNumbers(TreeNode node, string cur_num, IList<int> nums)
		{
			if (node == null)
				return;

			cur_num += node.val;
			if (node.left == null && node.right == null)
			{
				nums.Add(int.Parse(cur_num));
				return;
			}
			SumNumbers(node.left, cur_num, nums);
			SumNumbers(node.right, cur_num, nums);
		}
	}
}

using System.Collections.Generic;

namespace LeetCodeInCS._0095_Unique_Binary_Search_Trees_II
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
		public IList<TreeNode> GenerateTrees(int n)
		{
			if (n <= 0)
				return new List<TreeNode>();
			return GenerateTrees(1, n);
		}

		private IList<TreeNode> GenerateTrees(int start, int end)
		{
			IList<TreeNode> trees = new List<TreeNode>();
			if (start > end)
			{
				trees.Add(null);
				return trees;
			}

			for (int i = start; i <= end; i++)
			{
				IList<TreeNode> left = GenerateTrees(start, i - 1);
				IList<TreeNode> right = GenerateTrees(i + 1, end);

				foreach (TreeNode l_node in left)
				{
					foreach (TreeNode r_node in right)
					{
						TreeNode root = new TreeNode(i)
						{
							left = l_node,
							right = r_node
						};
						trees.Add(root);
					}
				}
			}
			return trees;
		}
	}
}

using System.Collections.Generic;

namespace LeetCodeInCS._0098_Validate_Binary_Search_Tree
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
		public bool IsValidBST(TreeNode root)
		{
			IList<int> vals = new List<int>();
			InOrder(root, vals);
			for (int i = 0; i < vals.Count - 1; i++)
			{
				if (vals[i] >= vals[i + 1])
					return false;
			}
			return true;
		}

		private void InOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			InOrder(node.left, list);
			list.Add(node.val);
			InOrder(node.right, list);
		}
	}

	public class Solution2
	{
		public bool IsValidBST(TreeNode root)
		{
			return IsValid(root, null, null);
		}

		private bool IsValid(TreeNode node, int? min, int? max)
		{
			if (node == null)
				return true;
			if (min != null && node.val <= min)
				return false;
			if (max != null && node.val >= max)
				return false;

			return IsValid(node.left, min, node.val)
				&& IsValid(node.right, node.val, max);
		}
	}
}

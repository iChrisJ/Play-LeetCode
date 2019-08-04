using System.Collections.Generic;

namespace CSharp._0098_Validate_Binary_Search_Tree
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
}

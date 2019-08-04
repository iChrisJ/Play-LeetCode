using System.Collections.Generic;

namespace CSharp._0257_Binary_Tree_Paths
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
		public IList<string> BinaryTreePaths(TreeNode root)
		{
			IList<string> res = new List<string>();

			if (root == null)
				return res;
			if (root.left == null && root.right == null)
			{
				res.Add(root.val.ToString());
				return res;
			}

			IList<string> leftStrs = BinaryTreePaths(root.left);
			foreach (var leftStr in leftStrs)
				res.Add(root.val + "->" + leftStr);

			IList<string> rightStrs = BinaryTreePaths(root.right);
			foreach (var rightStr in rightStrs)
				res.Add(root.val + "->" + rightStr);

			return res;;
		}
	}
}

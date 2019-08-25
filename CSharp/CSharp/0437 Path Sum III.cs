namespace CSharp._0437_Path_Sum_III
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
		public int PathSum(TreeNode root, int sum)
		{
			if (root == null)
				return 0;
			int res = FindPath(root, sum);
			res += PathSum(root.left, sum);
			res += PathSum(root.right, sum);
			return res;
		}

		private int FindPath(TreeNode node, int val)
		{
			if (node == null)
				return 0;
			int res = 0;
			if (node.val == val)
				res += 1;
			res += FindPath(node.left, val - node.val);
			res += FindPath(node.right, val - node.val);
			return res;
		}
	}
}

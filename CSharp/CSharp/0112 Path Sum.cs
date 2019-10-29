namespace LeetCodeInCS._0112_Path_Sum
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
		public bool HasPathSum(TreeNode root, int sum)
		{
			if (root == null)
				return false;
			if (root.left == null && root.right == null)
				return root.val == sum;
			return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
		}
	}
}

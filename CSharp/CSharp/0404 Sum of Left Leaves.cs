namespace LeetCodeInCS._0404_Sum_of_Left_Leaves
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
		public int SumOfLeftLeaves(TreeNode root)
		{
			int sum = 0;
			if (root == null)
				return 0;
			if (root.left != null && root.left.left == null && root.left.right == null)
				sum += root.left.val;
			sum += SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
			return sum;
		}
	}
}

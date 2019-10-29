namespace LeetCodeInCS._0222_Count_Complete_Tree_Nodes
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
		public int CountNodes(TreeNode root)
		{
			if (root == null)
				return 0;
			return CountNodes(root.left) + CountNodes(root.right) + 1;
		}
	}
}

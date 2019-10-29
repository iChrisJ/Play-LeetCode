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
}

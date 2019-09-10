namespace CSharp._0236_Lowest_Common_Ancestor_of_a_Binary_Tree
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
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null || root == p || root == q)
				return root;
			TreeNode left = LowestCommonAncestor(root.left, p, q);
			TreeNode right = LowestCommonAncestor(root.right, p, q);
			return left == null ? right : right == null ? left : root;
		}
	}
}

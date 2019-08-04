namespace CSharp._0101_Symmetric_Tree
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
		public bool IsSymmetric(TreeNode root)
		{
			if (root == null)
				return true;
			return IsSymmetricTree(root.left, root.right);
		}

		public bool IsSymmetricTree(TreeNode p, TreeNode q)
		{
			if (p != null && q != null)
			{
				if (p.val != q.val)
					return false;
				return IsSymmetricTree(p.left, q.right) && IsSymmetricTree(p.right, q.left);
			}
			else if (p == null && q == null)
				return true;
			else
				return false;
		}
	}
}

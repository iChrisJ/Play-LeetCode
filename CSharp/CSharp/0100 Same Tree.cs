namespace CSharp._0100_Same_Tree
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
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			if (p != null && q != null)
			{
				if (p.val != q.val)
					return false;
				return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
			}
			else if (p == null && q == null)
				return true;
			else
				return false;
		}
	}
}
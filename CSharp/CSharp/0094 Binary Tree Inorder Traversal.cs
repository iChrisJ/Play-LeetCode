using System.Collections.Generic;

namespace CSharp._0094_Binary_Tree_Inorder_Traversal
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
		public IList<int> InorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			InOrder(root, res);
			return res;
		}

		private void InOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			InOrder(node.left, list);
			list.Add(node.val);
			InOrder(node.right, list);
		}

		public IList<int> InorderTraversal2(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();

			TreeNode cur = root;
			while (cur != null || stack.Count != 0)
			{
				if (cur != null)
				{
					stack.Push(cur);
					cur = cur.left;
				}
				else
				{
					cur = stack.Pop();
					res.Add(cur.val);
					cur = cur.right;
				}
			}
			return res;
		}
	}

	public class Solution2
	{
		public IList<int> InorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();

			TreeNode cur = root;
			while (cur != null || stack.Count != 0)
			{
				if (cur != null)
				{
					stack.Push(cur);
					cur = cur.left;
				}
				else
				{
					cur = stack.Pop();
					res.Add(cur.val);
					cur = cur.right;
				}
			}
			return res;
		}
	}
}

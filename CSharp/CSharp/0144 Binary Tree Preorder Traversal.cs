using System.Collections.Generic;

namespace LeetCodeInCS._0144_Binary_Tree_Preorder_Traversal
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
		public IList<int> PreorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			Preorder(root, res);
			return res;
		}

		private void Preorder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			list.Add(node.val);
			Preorder(node.left, list);
			Preorder(node.right, list);
		}
	}

	public class Solution2
	{
		public IList<int> PreorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			Stack<TreeNode> stack = new Stack<TreeNode>();
			if (root != null)
				stack.Push(root);
			while (stack.Count != 0)
			{
				TreeNode node = stack.Pop();
				if (node.right != null)
					stack.Push(node.right);
				if (node.left != null)
					stack.Push(node.left);
				res.Add(node.val);
			}
			return res;
		}
	}
}

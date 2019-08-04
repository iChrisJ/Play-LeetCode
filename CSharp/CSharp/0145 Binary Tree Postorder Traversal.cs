using System.Collections.Generic;

namespace CSharp._0145_Binary_Tree_Postorder_Traversal
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
		public IList<int> PostorderTraversal(TreeNode root)
		{
			IList<int> res = new List<int>();
			PostOrder(root, res);
			return res;
		}
		private void PostOrder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			PostOrder(node.left, list);
			PostOrder(node.right, list);
			list.Add(node.val);
		}

		struct Command
		{
			public char c;
			public TreeNode node;
			public Command(char c, TreeNode node)
			{
				this.c = c;
				this.node = node;
			}
		}

		public IList<int> PostorderTraversal2(TreeNode root)
		{
			IList<int> res = new List<int>();

			Stack<Command> stack = new Stack<Command>();
			if (root != null)
				stack.Push(new Command('g', root));
			while (stack.Count != 0)
			{
				Command top = stack.Pop();
				if (top.c == 'p')
					res.Add(top.node.val);
				else
				{
					if (top.node.left != null)
						stack.Push(new Command('g', top.node.left));
					if (top.node.right != null)
						stack.Push(new Command('g', top.node.right));
					stack.Push(new Command('p', top.node));
				}
			}
			return res;
		}
	}
}

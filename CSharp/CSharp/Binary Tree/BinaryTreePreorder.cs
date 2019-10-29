using System.Collections.Generic;

namespace LeetCodeInCS.Binary_Tree
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	class BinaryTreePreorder_Solution
	{
		// Recursive
		public IList<int> Preorder(TreeNode root)
		{
			List<int> res = new List<int>();
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

	class BinaryTreePreorder_Solution2
	{
		// Traversal
		public IList<int> Preorder(TreeNode root)
		{
			List<int> res = new List<int>();
			Stack<TreeNode> stack = new Stack<TreeNode>();

			if (root != null)
				stack.Push(root);
			while (stack.Count != 0)
			{
				TreeNode node = stack.Pop();
				res.Add(node.val);
				if (node.right != null)
					stack.Push(node.right);
				if (node.left != null)
					stack.Push(node.left);
			}
			return res;
		}
	}

	class BinaryTreePreorder_Solution3
	{
		// Traversal
		public IList<int> Preorder(TreeNode root)
		{
			List<int> res = new List<int>();
			Stack<Command> stack = new Stack<Command>();

			if (root != null)
				stack.Push(new Command(true, root));
			while (stack.Count != 0)
			{
				Command comm = stack.Pop();

				if (comm.IsVisit == false)
					res.Add(comm.Node.val);
				else
				{
					if (comm.Node.right != null)
						stack.Push(new Command(true, comm.Node.right));
					if (comm.Node.left != null)
						stack.Push(new Command(true, comm.Node.left));
					stack.Push(new Command(false, comm.Node));
				}
			}
			return res;
		}

		private class Command
		{
			// True, visit the node; false, put the value in the result list.
			public bool IsVisit { get; set; }
			public TreeNode Node { get; set; }
			public Command(bool isVisit, TreeNode node)
			{
				IsVisit = isVisit;
				Node = node;
			}
		}
	}
}

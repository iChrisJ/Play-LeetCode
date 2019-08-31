using System.Collections.Generic;

namespace CSharp.Binary_Tree
{
	class BinaryTreeInorder_Solution
	{
		// Recursive
		public IList<int> Inorder(TreeNode root)
		{
			List<int> res = new List<int>();
			Inorder(root, res);
			return res;
		}

		private void Inorder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			Inorder(node.left, list);
			list.Add(node.val);
			Inorder(node.right, list);
		}
	}

	class BinaryTreeInorder_Solution2
	{
		// Traversal
		public IList<int> Inorder(TreeNode root)
		{
			List<int> res = new List<int>();

			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			TreeNode cur = root;

			while (cur != null && stack.Count != 0)
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

	class BinaryTreeInorder_Solution3
	{
		// Traversal
		public IList<int> Inorder(TreeNode root)
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
					stack.Push(new Command(false, comm.Node));
					if (comm.Node.left != null)
						stack.Push(new Command(true, comm.Node.left));
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

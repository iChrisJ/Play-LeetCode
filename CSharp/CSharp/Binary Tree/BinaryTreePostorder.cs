using System.Collections.Generic;

namespace LeetCodeInCS.Binary_Tree
{
	class BinaryTreePostorder_Solution
	{
		public IList<int> Postorder(TreeNode root)
		{
			List<int> res = new List<int>();
			Postorder(root, res);
			return res;
		}

		private void Postorder(TreeNode node, IList<int> list)
		{
			if (node == null)
				return;
			Postorder(node.left, list);
			Postorder(node.right, list);
			list.Add(node.val);
		}
	}

	class BinaryTreePostorder_Solution2
	{
		/// <summary>
		/// 使用一个栈实现
		/// 具体过程如下
		/// 1. 申请一个, 记为stack, 将头节点压入stack, 同时设置两个变量recent和c。在整个流程中, recent代表最近一次弹出并打印的节点, c代表当前stack的栈顶节点, 初始时令recent为头节点, c为null
		/// 2. 每次令c等于当前stack的栈顶节点, 但是不从stack中弹出节点, 此时分以下三种情况。
		/// (1) 如果c的左孩子不为空, 并且recent不等于c的左孩子, 也不等于c的右孩子, 则把c的左孩子压入stack中
		/// (2) 如果情况1不成立, 并且c的右孩子不为空, 并且recent不等于c的右孩子, 则把c的右孩子压入stack中。
		/// (3) 如果情况1和情况2都不成立, 那么从stack中弹出c并打印, 然后令recent等于c
		/// 3. 一直重复步骤2, 直到stack为空, 过程停止
		/// </summary>
		public IList<int> Postorder(TreeNode root)
		{
			List<int> res = new List<int>();

			if (root == null)
				return res;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			stack.Push(root);
			TreeNode recent = root, cur = null;
			while (stack.Count != 0)
			{
				cur = stack.Peek();

				if (cur.left != null && recent != cur.left && recent != cur.right)
					stack.Push(cur.left);
				else if (cur.right != null && recent != cur.right)
					stack.Push(cur.right);
				else
				{
					res.Add(stack.Pop().val);
					recent = cur;
				}
			}
			return res;
		}
	}

	class BinaryTreePostorder_Solution3
	{
		public IList<int> Postorder(TreeNode root)
		{
			List<int> res = new List<int>();

			Stack<TreeNode> stack1 = new Stack<TreeNode>();
			if (root != null)
				stack1.Push(root);

			Stack<TreeNode> stack2 = new Stack<TreeNode>();
			while (stack1.Count != 0)
			{
				TreeNode node = stack1.Pop();
				if (node.left != null)
					stack1.Push(node.left);
				if (node.right != null)
					stack1.Push(node.right);
				stack2.Push(node);
			}

			while (stack2.Count != 0)
				res.Add(stack2.Pop().val);

			return res;
		}
	}

	class BinaryTreePostorder_Solution4
	{
		public IList<int> Postorder(TreeNode root)
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
					stack.Push(new Command(false, comm.Node));
					if (comm.Node.right != null)
						stack.Push(new Command(true, comm.Node.right));
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

using System.Collections.Generic;

namespace LeetCodeInCS._0103_Binary_Tree_Zigzag_Level_Order_Traversal
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
		public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			Queue<TreeNode> queue = new Queue<TreeNode>();

			if (root != null)
				queue.Enqueue(root);
			bool isReverse = false;
			while (queue.Count != 0)
			{
				int len = queue.Count;
				IList<int> line = new List<int>();
				Stack<int> stack = new Stack<int>();
				for (int i = 0; i < len; i++)
				{
					TreeNode front = queue.Dequeue();
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);

					if (isReverse)
						stack.Push(front.val);
					else
						line.Add(front.val);
				}
				if (isReverse)
					res.Add(new List<int>(stack));
				else
					res.Add(line);
				isReverse = !isReverse;
			}
			return res;
		}
	}
}

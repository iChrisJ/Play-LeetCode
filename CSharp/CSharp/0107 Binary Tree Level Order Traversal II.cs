using System.Collections.Generic;

namespace LeetCodeInCS._0107_Binary_Tree_Level_Order_Traversal_II
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
		public IList<IList<int>> LevelOrderBottom(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			Queue<TreeNode> queue = new Queue<TreeNode>();
			Stack<IList<int>> stack = new Stack<IList<int>>();

			if (root != null)
				queue.Enqueue(root);

			while (queue.Count != 0)
			{
				int levelNodeCount = queue.Count;
				IList<int> nodes = new List<int>();
				for (int i = 0; i < levelNodeCount; i++)
				{
					TreeNode front = queue.Dequeue();
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);
					nodes.Add(front.val);
				}
				stack.Push(nodes);
			}

			while (stack.Count != 0)
				res.Add(stack.Pop());

			return res;
		}
	}
}

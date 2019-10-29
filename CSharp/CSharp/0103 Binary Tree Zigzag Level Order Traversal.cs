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
			bool isAsc = true;
			while (queue.Count != 0)
			{
				int levelNodeCount = queue.Count;
				IList<int> nodes = new List<int>();
				Stack<int> nodeStack = new Stack<int>();
				for (int i = 0; i < levelNodeCount; i++)
				{
					TreeNode front = queue.Dequeue();
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);
					if (isAsc)
						nodes.Add(front.val);
					else
						nodeStack.Push(front.val);
				}
				if (!isAsc)
				{
					while (nodeStack.Count != 0)
						nodes.Add(nodeStack.Pop());
				}
				res.Add(nodes);
				isAsc = !isAsc;
			}
			return res;
		}
	}
}

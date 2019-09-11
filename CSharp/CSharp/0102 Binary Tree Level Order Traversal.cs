using System.Collections.Generic;

namespace CSharp._0102_Binary_Tree_Level_Order_Traversal
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
		// BFS
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			Queue<TreeNode> queue = new Queue<TreeNode>();

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
				res.Add(nodes);
			}
			return res;
		}
	}

	public class Solution2
	{
		// DFS
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			LevelOrderDFS(root, 1, res);
			return res;
		}

		private void LevelOrderDFS(TreeNode node, int level, IList<IList<int>> res)
		{
			if (node == null)
				return;

			if (res.Count >= level)
				res[level - 1].Add(node.val);
			else
				res.Add(new List<int>() { node.val });
			LevelOrderDFS(node.left, level + 1, res);
			LevelOrderDFS(node.right, level + 1, res);
		}
	}
}

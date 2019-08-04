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
}

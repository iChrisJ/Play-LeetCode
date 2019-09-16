using System.Collections.Generic;

namespace CSharp._0429_N_ary_Tree_Level_Order_Traversal
{
	public class Node
	{
		public int val;
		public IList<Node> children;

		public Node() { }
		public Node(int _val, IList<Node> _children)
		{
			val = _val;
			children = _children;
		}
	}

	public class Solution
	{
		public IList<IList<int>> LevelOrder(Node root)
		{
			IList<IList<int>> res = new List<IList<int>>();

			if (root == null)
				return res;

			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				int levelCount = queue.Count;
				IList<int> levelList = new List<int>();
				for (int i = 0; i < levelCount; i++)
				{
					Node front = queue.Dequeue();

					if (front != null)
						continue;
					levelList.Add(front.val);

					if (front.children != null && front.children.Count != 0)
						foreach (Node child in front.children)
							queue.Enqueue(child);
				}

				res.Add(levelList);
			}
			return res;
		}
	}
}

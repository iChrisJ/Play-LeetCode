using System;
using System.Collections.Generic;

namespace CSharp._0559_Maximum_Depth_of_N_ary_Tree
{
	// Definition for a Node.
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

	/// <summary>
	/// DFS
	/// </summary>
	public class Solution
	{
		public int MaxDepth(Node root)
		{
			if (root == null)
				return 0;
			if (root.children == null || root.children.Count == 0)
				return 1;

			int max = 0;
			for (int i = 0; i < root.children.Count; i++)
				max = Math.Max(max, MaxDepth(root.children[i]));
			return max + 1;
		}
	}

	/// <summary>
	/// BFS
	/// </summary>
	public class Solution2
	{
		public int MaxDepth(Node root)
		{
			if (root == null)
				return 0;

			int depth = 0;
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);
			while (queue.Count != 0)
			{
				depth++;
				int levelCount = queue.Count;
				for (int i = 0; i < levelCount; i++)
				{
					Node node = queue.Dequeue();
					if (node.children != null && node.children.Count > 0)
						foreach (Node child in node.children)
							queue.Enqueue(child);
				}
			}
			return depth;
		}
	}
}

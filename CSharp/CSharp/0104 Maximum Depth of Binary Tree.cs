using System;
using System.Collections.Generic;

namespace CSharp._0104_Maximum_Depth_of_Binary_Tree
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
		// DFS
		public int MaxDepth(TreeNode root)
		{
			if (root == null)
				return 0;
			return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
		}
	}

	public class Solution2
	{
		// BFS
		public int MaxDepth(TreeNode root)
		{
			if (root == null)
				return 0;

			Queue<TreeNode> queue = new Queue<TreeNode>();

			queue.Enqueue(root);
			int depth = 0;

			while (queue.Count != 0)
			{
				depth++;
				int count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					TreeNode node = queue.Dequeue();
					if (node.left != null)
						queue.Enqueue(node.left);
					if (node.right != null)
						queue.Enqueue(node.right);
				}
			}
			return depth;
		}
	}
}

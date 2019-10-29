using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0111_Minimum_Depth_of_Binary_Tree
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
		public int MinDepth(TreeNode root)
		{
			if (root == null)
				return 0;
			int left = MinDepth(root.left);
			int right = MinDepth(root.right);
			return (left == 0 || right == 0) ? left + right + 1 : Math.Min(left, right) + 1;
		}
	}

	public class Solution2
	{
		// BFS
		public int MinDepth(TreeNode root)
		{
			if (root == null)
				return 0;

			int left = MinDepthBFS(root.left);
			int right = MinDepthBFS(root.right);
			return left == 0 || right == 0 ? left + right + 1 : Math.Min(left, right) + 1;

		}

		private int MinDepthBFS(TreeNode node)
		{
			if (node == null)
				return 0;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(node);
			int minDepth = 0;

			while (queue.Count != 0)
			{
				minDepth++;
				int count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					TreeNode front = queue.Dequeue();
					if (front.left == null && front.right == null)
						return minDepth;
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);
				}
			}
			return minDepth;
		}
	}
}

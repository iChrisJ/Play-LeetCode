using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0513_Find_Bottom_Left_Tree_Value
{
	// Definition for a binary tree node.
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		public int FindBottomLeftValue(TreeNode root)
		{
			if (root == null)
				throw new ArgumentException("Invalid exception.");

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			int res = root.val;

			while (queue.Count != 0)
			{
				int levelCount = queue.Count;

				for (int i = 0; i < levelCount; i++)
				{
					TreeNode front = queue.Dequeue();
					if (i == 0)
						res = front.val;

					if (front.left != null)
						queue.Enqueue(front.left);

					if (front.right != null)
						queue.Enqueue(front.right);
				}
			}
			return res;
		}
	}

	public class Solution2
	{
		public int FindBottomLeftValue(TreeNode root)
		{
			if (root == null)
				throw new ArgumentException("Invalid exception.");

			int depth = 0;
			(int, int) res = (root.val, depth); // store the value of the leftmost TreeNode and its depth.

			DFS(root, depth, ref res);

			return res.Item1;
		}

		private (int, int) DFS(TreeNode node, int depth, ref (int, int) res)
		{
			if (node == null)
				return res;

			if (res.Item2 < depth)
				res = (node.val, depth);

			DFS(node.left, depth + 1, ref res);
			DFS(node.right, depth + 1, ref res);

			return res;
		}
	}
}

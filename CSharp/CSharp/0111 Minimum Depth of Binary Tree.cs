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

	/// <summary>
	/// BFS
	/// </summary>
	public class Solution2
	{
		public int MinDepth(TreeNode root)
		{
			if (root == null)
				return 0;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			int depth = 0;

			while (queue.Count > 0)
			{
				depth++;
				int len = queue.Count;
				while (len > 0)
				{
					TreeNode frnt = queue.Dequeue();
					if (frnt.left == null && frnt.right == null)
						return depth;

					if (frnt.left != null)
						queue.Enqueue(frnt.left);
					if (frnt.right != null)
						queue.Enqueue(frnt.right);
					len--;
				}
			}
			return depth;
		}
	}
}

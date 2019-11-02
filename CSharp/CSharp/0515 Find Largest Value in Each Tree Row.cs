using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0515_Find_Largest_Value_in_Each_Tree_Row
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
		public IList<int> LargestValues(TreeNode root)
		{
			IList<int> res = new List<int>();

			if (root == null)
				return res;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				int levelCount = queue.Count;

				int max = int.MinValue;
				for (int i = 0; i < levelCount; i++)
				{
					TreeNode front = queue.Dequeue();
					max = Math.Max(max, front.val);

					if (front.left != null)
						queue.Enqueue(front.left);

					if (front.right != null)
						queue.Enqueue(front.right);
				}

				res.Add(max);
			}

			return res;
		}
	}

	public class Solution2
	{
		public IList<int> LargestValues(TreeNode root)
		{
			IList<int> res = new List<int>();

			if (root == null)
				return res;

			DFS(root, res, 0);
			return res;
		}

		private void DFS(TreeNode node, IList<int> res, int depth)
		{
			if (node == null)
				return;

			if (res.Count >= depth + 1)
				res[depth] = Math.Max(res[depth], node.val);
			else
				res.Add(node.val);

			DFS(node.left, res, depth + 1);
			DFS(node.right, res, depth + 1);
		}
	}
}

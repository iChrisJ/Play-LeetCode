using System;

namespace LeetCodeInCS._0222_Count_Complete_Tree_Nodes
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
		public int CountNodes(TreeNode root)
		{
			if (root == null)
				return 0;
			return CountNodes(root.left) + CountNodes(root.right) + 1;
		}
	}

	public class Solution2
	{
		// Return tree depth in O(d) time.
		public int ComputeDepth(TreeNode node)
		{
			int d = 0;
			while (node.left != null)
			{
				node = node.left;
				++d;
			}
			return d;
		}

		// Last level nodes are enumerated from 0 to 2**d - 1 (left -> right).
		// Return True if last level node idx exists. 
		// Binary search with O(d) complexity.
		public bool Exists(int idx, int d, TreeNode node)
		{
			int left = 0, right = (int)Math.Pow(2, d) - 1;
			int pivot;
			for (int i = 0; i < d; ++i)
			{
				pivot = left + (right - left) / 2;
				if (idx <= pivot)
				{
					node = node.left;
					right = pivot;
				}
				else
				{
					node = node.right;
					left = pivot + 1;
				}
			}
			return node != null;
		}

		public int CountNodes(TreeNode root)
		{
			// if the tree is empty
			if (root == null) return 0;

			int d = ComputeDepth(root);
			// if the tree contains 1 node
			if (d == 0) return 1;

			// Last level nodes are enumerated from 0 to 2**d - 1 (left -> right).
			// Perform binary search to check how many nodes exist.
			int left = 1, right = (int)Math.Pow(2, d) - 1;
			int pivot;
			while (left <= right)
			{
				pivot = left + (right - left) / 2;
				if (Exists(pivot, d, root)) left = pivot + 1;
				else right = pivot - 1;
			}

			// The tree contains 2**d - 1 nodes on the first (d - 1) levels
			// and left nodes on the last level.
			return (int)Math.Pow(2, d) - 1 + left;
		}
	}
}

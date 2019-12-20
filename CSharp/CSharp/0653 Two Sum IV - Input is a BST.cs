using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0653_Two_Sum_IV___Input_is_a_BST
{
	// Definition for a binary tree node.
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	/// <summary>
	/// InOrder to convert the tree to a sorted array, then traverse the array with two points
	/// </summary>
	public class Solution
	{
		public bool FindTarget(TreeNode root, int k)
		{
			if (root == null)
				return false;

			List<int> arr = new List<int>();
			InOrder(root, arr);

			for (int i = 0, j = arr.Count - 1; i < j;)
			{
				if (arr[i] + arr[j] > k)
					j--;
				else if (arr[i] + arr[j] < k)
					i++;
				else
					return true;
			}
			return false;
		}

		private void InOrder(TreeNode node, List<int> arr)
		{
			if (node == null)
				return;

			InOrder(node.left, arr);
			arr.Add(node.val);
			InOrder(node.right, arr);
		}
	}

	/// <summary>
	/// DFS to traverse the tree and store the traversed node in Set.
	/// </summary>
	public class Solution2
	{
		public bool FindTarget(TreeNode root, int k)
		{
			if (root == null)
				return false;

			HashSet<int> set = new HashSet<int>();
			return DFS(root, set, k);
		}

		private bool DFS(TreeNode node, HashSet<int> set, int k)
		{
			if (node == null)
				return false;

			if (set.Contains(k - node.val))
				return true;
			else
			{
				set.Add(node.val);
				return DFS(node.left, set, k) || DFS(node.right, set, k);
			}
		}
	}
}

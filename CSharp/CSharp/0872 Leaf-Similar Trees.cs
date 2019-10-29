using System.Collections.Generic;

namespace LeetCodeInCS._0872_Leaf_Similar_Trees
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}
	/// <summary>
	/// DFS
	/// BFS is not working in this problem.
	/// </summary>
	public class Solution
	{
		public bool LeafSimilar(TreeNode root1, TreeNode root2)
		{
			if (root1 == null || root2 == null)
				return root1 == root2;

			Queue<int> leaves1 = new Queue<int>();
			DFS(root1, leaves1);

			Queue<int> leaves2 = new Queue<int>();
			DFS(root2, leaves2);

			while (leaves1.Count != 0 && leaves2.Count != 0)
			{
				if (leaves1.Dequeue() != leaves2.Dequeue())
					return false;
			}

			return leaves1.Count == 0 && leaves2.Count == 0;
		}

		private void DFS(TreeNode node, Queue<int> leaves)
		{
			if (node == null)
				return;
			if (node.left == null && node.right == null)
				leaves.Enqueue(node.val);

			DFS(node.left, leaves);
			DFS(node.right, leaves);
		}
	}
}

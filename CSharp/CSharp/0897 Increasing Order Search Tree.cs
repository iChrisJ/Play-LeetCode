using System.Collections.Generic;

namespace LeetCodeInCS._0897_Increasing_Order_Search_Tree
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
		public TreeNode IncreasingBST(TreeNode root)
		{
			if (root == null)
				return null;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			DFS(root, queue);

			TreeNode res = queue.Dequeue();
			TreeNode cur = res;
			cur.left = null;
			cur.right = null;

			while (queue.Count != 0)
			{
				cur.right = queue.Dequeue();
				cur = cur.right;
				cur.left = null;
				cur.right = null;
			}
			return res;
		}

		private void DFS(TreeNode node, Queue<TreeNode> queue)
		{
			if (node == null)
				return;
			DFS(node.left, queue);
			queue.Enqueue(node);
			DFS(node.right, queue);
		}
	}
}

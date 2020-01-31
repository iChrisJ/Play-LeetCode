using System.Collections.Generic;

namespace LeetCodeInCS._0199_Binary_Tree_Right_Side_View
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	/// <summary>
	/// BFS
	/// </summary>
	public class Solution
	{
		public IList<int> RightSideView(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				int len = queue.Count;
				while (len > 0)
				{
					TreeNode front = queue.Dequeue();
					if (len == 1)
						res.Add(front.val);

					if (front.left != null)
						queue.Enqueue(front.left);

					if (front.right != null)
						queue.Enqueue(front.right);
					len--;
				}
			}
			return res;
		}
	}

	/// <summary>
	/// DFS
	/// </summary>
	public class Solution2
	{
		public IList<int> RightSideView(TreeNode root)
		{
			IList<int> res = new List<int>();
			if (root == null)
				return res;

			DFS(root, 0, res);
			return res;
		}

		private void DFS(TreeNode node, int level, IList<int> res)
		{
			if (node == null)
				return;

			if (level == res.Count)
				res.Add(node.val);
			DFS(node.right, level + 1, res);
			DFS(node.left, level + 1, res);
		}
	}
}

using System.Collections.Generic;

namespace LeetCodeInCS._0100_Same_Tree
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	// DFS
	public class Solution
	{
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			if (p == null && q == null)
				return true;
			else if (p != null && q != null)
				return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
			return false;
		}
	}

	// BFS
	public class Solution2
	{
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			Queue<TreeNode> p_queue = new Queue<TreeNode>();
			p_queue.Enqueue(p);
			Queue<TreeNode> q_queue = new Queue<TreeNode>();
			q_queue.Enqueue(q);

			while (p_queue.Count > 0 && q_queue.Count > 0)
			{
				TreeNode p_frnt = p_queue.Dequeue();
				TreeNode q_frnt = q_queue.Dequeue();

				if (p_frnt == null && q_frnt == null)
					continue;
				else if (p_frnt != null && q_frnt != null && p_frnt.val == q_frnt.val)
				{
					p_queue.Enqueue(p_frnt.left);
					p_queue.Enqueue(p_frnt.right);
					q_queue.Enqueue(q_frnt.left);
					q_queue.Enqueue(q_frnt.right);
				}
				else
					return false;
			}

			return p_queue.Count == 0 && q_queue.Count == 0;
		}
	}
}
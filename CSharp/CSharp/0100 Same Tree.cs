using System.Collections.Generic;

namespace CSharp._0100_Same_Tree
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
			if (p != null && q != null)
			{
				if (p.val != q.val)
					return false;
				return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
			}
			else if (p == null && q == null)
				return true;
			else
				return false;
		}
	}

	// BFS
	public class Solution2
	{
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			Queue<TreeNode> pQueue = new Queue<TreeNode>();
			pQueue.Enqueue(p);
			Queue<TreeNode> qQueue = new Queue<TreeNode>();
			qQueue.Enqueue(q);

			while (pQueue.Count != 0 && qQueue.Count != 0)
			{
				TreeNode pTop = pQueue.Dequeue();
				TreeNode qTop = qQueue.Dequeue();

				if (pTop == null && qTop == null)
					continue;

				if (pTop != null && qTop != null && pTop.val == qTop.val)
				{
					pQueue.Enqueue(pTop.left);
					pQueue.Enqueue(pTop.right);
					qQueue.Enqueue(qTop.left);
					qQueue.Enqueue(qTop.right);
					continue;
				}
				return false;
			}

			return pQueue.Count == 0 && qQueue.Count == 0;
		}
	}
}
﻿using System.Collections.Generic;

namespace LeetCodeInCS._0101_Symmetric_Tree
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
		public bool IsSymmetric(TreeNode root)
		{
			if (root == null)
				return true;
			return IsSymmetricTree(root.left, root.right);
		}

		public bool IsSymmetricTree(TreeNode p, TreeNode q)
		{
			if (p != null && q != null)
			{
				if (p.val != q.val)
					return false;
				return IsSymmetricTree(p.left, q.right) && IsSymmetricTree(p.right, q.left);
			}
			else if (p == null && q == null)
				return true;
			else
				return false;
		}
	}

	public class Solution2
	{
		public bool IsSymmetric(TreeNode root)
		{
			if (root == null)
				return true;

			Queue<TreeNode> l_queue = new Queue<TreeNode>();
			Queue<TreeNode> r_queue = new Queue<TreeNode>();
			l_queue.Enqueue(root.left);
			r_queue.Enqueue(root.right);

			while (l_queue.Count > 0 && r_queue.Count > 0)
			{
				TreeNode l_front = l_queue.Dequeue();
				TreeNode r_front = r_queue.Dequeue();

				if (l_front == null && r_front == null)
					continue;
				else if ((l_front == null && r_front != null) || (l_front != null && r_front == null) || (l_front.val != r_front.val))
					return false;
				else // l_front.val == r_front.val
				{
					l_queue.Enqueue(l_front.left);
					l_queue.Enqueue(l_front.right);
					r_queue.Enqueue(r_front.right);
					r_queue.Enqueue(r_front.left);
				}
			}
			return l_queue.Count == 0 && r_queue.Count == 0;
		}
	}
}

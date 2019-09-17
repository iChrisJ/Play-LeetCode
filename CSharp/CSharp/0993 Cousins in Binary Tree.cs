using System;
using System.Collections.Generic;

namespace CSharp._0993_Cousins_in_Binary_Tree
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
		public bool IsCousins(TreeNode root, int x, int y)
		{
			if (root == null || x == y)
				throw new Exception("Incorrect parameters.");

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				int levelCount = queue.Count;
				TreeNode xParent = null;
				TreeNode yParent = null;

				for (int i = 0; i < levelCount; i++)
				{
					TreeNode front = queue.Dequeue();

					if (front.left != null)
					{
						if (front.left.val == x)
							xParent = front;
						if (front.left.val == y)
							yParent = front;
						queue.Enqueue(front.left);
					}

					if (front.right != null)
					{
						if (front.right.val == x)
							xParent = front;
						if (front.right.val == y)
							yParent = front;
						queue.Enqueue(front.right);
					}
				}

				if (xParent != null && yParent != null)
					return xParent != yParent;
				else if (xParent == null && yParent == null)
					continue;
				else
					return false;
			}
			return false;
		}
	}
}

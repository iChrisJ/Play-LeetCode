using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Binary_Search
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	/// <summary>
	/// 给定一棵完全二叉树的头节点head, 返回这棵树的节点个数.
	/// 如果完全二叉树的节点数为N,请实现时间复杂度低于O(N)的解法.
	/// </summary>
	class CountCompleteTreeNodes_Solution
	{
		public int CountCompleteTreeNodes(TreeNode root)
		{
			if (root == null)
				return 0;

			int leftHeight = GetHeight(root.left);
			int rightHeight = GetHeight(root.right);

			if (leftHeight == 0)
			{
				return 1;
			}
			else if (rightHeight == 0)
			{
				return ((int)Math.Pow(2, leftHeight));
			}
			//leftHeight != 0 && rightHeight != 0
			//leftSubtree is full
			if (leftHeight == rightHeight)
			{
				return ((int)Math.Pow(2, leftHeight)) + CountCompleteTreeNodes(root.right);
			}
			//rightSubtree is full
			return ((int)Math.Pow(2, rightHeight)) + CountCompleteTreeNodes(root.left);
		}

		private int GetHeight(TreeNode node)
		{
			if (node == null)
				return 0;
			return 1 + GetHeight(node.left);
		}
	}
}

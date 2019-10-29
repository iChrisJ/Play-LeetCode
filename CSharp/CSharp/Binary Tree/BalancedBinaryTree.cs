using System;

namespace LeetCodeInCS.Binary_Tree
{
	/// <summary>
	/// 平衡二叉树(AVL树)
	/// 1. 空树是平衡二叉树
	/// 2. 如果一棵树不为空, 并且其所有子树都满足各自的左子树和右子树的高度差不超过1
	/// 平衡二叉树:
	///       1                  1
	///    /     \            /     \
	///   2       3          2       3
	///  / \     / \        /         \
	/// 4   5   6   7      4           7
	/// 非平衡二叉树:
	///        1
	///      /   \
	///     2     3
	///    /       \
	///   4         7
	///  /
	/// 8
	/// 
	/// 题: 给定一棵二叉树的头节点root, 判断一棵树是否是平衡二叉树
	/// </summary>
	class BalancedBinaryTree
	{
		public bool IsBalanced(TreeNode root)
		{
			if (root == null)
				return true;
			return IsBalanced(root.left) && IsBalanced(root.right)
				&& Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1;
		}

		private int GetHeight(TreeNode node)
		{
			if (node == null)
				return 0;
			return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
		}
	}
}

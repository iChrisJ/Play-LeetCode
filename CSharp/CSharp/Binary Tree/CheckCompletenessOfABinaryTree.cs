using System.Collections.Generic;

namespace CSharp.Binary_Tree
{
	/// <summary>
	/// 满二叉树:
	/// 满二叉树是除了最后一层的节点无任何子节点外, 剩下每一层上的节点都有两个子节点. 
	///        1
	///     /     \
	///    2       3
	///  /   \   /   \
	/// 4     5 6     7
	/// 满二叉树的层数即为L, 节点数即为N, 则 N = 2**L-1, L=log(N+1)
	/// 
	/// 完全二叉树:
	/// 完全二叉树是指除了最后一层之外, 其他每一层的节点数都是满的. 最后一层如果也满了是一颗满二叉树也是完全二叉树. 
	/// 最后一层如果不满, 缺少的节点也全部的集中在右边, 那也是一颗完全二叉树
	///        1         ---满完全二叉树
	///     /     \
	///    2       3
	///  /   \   /   \
	/// 4     5 6     7
	/// 
	///        1                 1      ---完全二叉树
	///     /     \            /   \
	///    2       3          2     3
	///  /   \   /           /
	/// 4     5 6           4
	/// 
	/// 题: 给定一棵二叉树的头节点head, 判断一棵树是否是完全二叉树
	/// 1. 采用按层遍历二叉树的方式从每层的左边向右边依次遍历所有的节点
	/// 2. 如果当前节点有右孩子, 但没有左孩子, 直接返回 false.
	/// 3. 如果当前节点并不是左右孩子全有, 那之后的节点必须都为叶节点否则返回 false
	/// 4. 遍历过程中如果不返回 false遍历结束后返回true即可
	/// </summary>
	class CheckCompletenessOfABinaryTree
	{
		public bool IsCompleteTree(TreeNode root)
		{
			if (root == null || (root.left == null && root.right == null))
				return true;

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			bool prevLevelHasNull = false;

			while (queue.Count != 0)
			{
				TreeNode node = queue.Dequeue();

				if (prevLevelHasNull && (node.left != null || node.right != null))
					return false;

				if (node.left == null && node.right != null)
					return false;
				else if (node.left != null & node.right == null)
				{
					queue.Enqueue(node.left);
					prevLevelHasNull = true;
				}
				else if (node.left != null & node.right != null)
				{
					queue.Enqueue(node.left);
					queue.Enqueue(node.right);
				}
				else
					prevLevelHasNull = true;
			}

			return true;
		}
	}
}

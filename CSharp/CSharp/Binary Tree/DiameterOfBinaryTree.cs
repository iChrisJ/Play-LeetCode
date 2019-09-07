using System;

namespace CSharp.Binary_Tree
{
	/// <summary>
	/// 从二叉树的节点A出发，可以向上或者向下走，但沿途的节点只能经过一次，当到达节点B时，路径上的节点数叫作A到B的距离。
	/// 比如大家看到的图中，节点4和节点2的距离为2，节点5和节点6的距离为5。给定一棵二叉树的头节点head，求整棵树上节点间的最大距离
	///        1
	///     /     \
	///    2       3
	///  /   \   /   \
	/// 4     5 6     7
	/// 
	/// 一个以h为头的树上最大距离只可能来自以下三种情况：
	/// 情况一：h的左子树上的最大距离
	/// 情况二：h的右子树上的最大距离。
	/// 情况三；h左子树上离h左孩子最远的距离，加上h自身这个节点，再加h右子树上离h右孩子的最远距离，也就是两个节点分别来自h两侧子树的情况。
	/// 三个值中最大的那个就是以h为头的整棵树上最远的距离。
	/// 
	/// 步骤
	/// 1. 整个过程为后序遍历，在二叉树的每棵子树上执行步骤2
	/// 2. 假设子树头为h，处理h左子树，得到两个信息，左子树上的最大距离记为LMax1，左子树上距离h左孩子的最远距离记为LMax2。
	/// 处理h右子树得到右子树上的最大距离记为RMax1，距离h右孩子的最远距离记为RMax2。那么跨h节点情况下的最大距离为LMax2+1+RMax2，
	/// 这个值与LMax1和RMa1比较，最大值为，以头h的树上的最大距离。
	/// 3. LMax2+1就是h左子树上离h最远的点到h的距离，RMax2+1就是h右子树上离h最远的点到h的距离，选两者中最大的一个作为h树上距离h最远的距离返回
	/// 4. 如何返回左右子树上距离最远点的距离，用返回长度为2的数组的方式，可以做的返回两个值
	/// </summary>
	class DiameterOfBinaryTree
	{
		private int maxDistance;

		public int DiameterBinaryTree(TreeNode root)
		{
			if (root == null)
				return 0;

			int left = 0, right = 0;

			left = GetMaxDepth(root.left);
			right = GetMaxDepth(root.right);

			return Math.Max(left + right + 1, maxDistance);
		}

		private int GetMaxDepth(TreeNode node)
		{
			if (node == null)
				return 0;

			int left = 0, right = 0;

			left = GetMaxDepth(node.left);
			right = GetMaxDepth(node.right);

			maxDistance = Math.Max(maxDistance, left + right + 1);

			return 1 + Math.Max(left, right); ;
		}
	}
}

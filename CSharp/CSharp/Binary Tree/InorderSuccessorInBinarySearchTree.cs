using System;

namespace LeetCodeInCS.Binary_Tree
{
	/// <summary>
	/// 后继节点:
	/// 一个节点的后继节点是指, 这个节点在中序遍历序列中的下一个节点.
	///        A
	///     /     \
	///    B       C
	///  /   \   /   \
	/// D     E F     G
	/// 中序遍历的序列为DBEAFCG
	/// 
	/// 前驱节点:
	/// 这个节点在中序遍历序列中的上一个节点.
	/// 
	/// 题: 现在有一种新的二叉树节点类型, 定义如大家所见 Class Node
	/// 该结构比普通二叉树节点结构多了一个指向父节点的 parent指针. 
	/// 假设有一棵这种类型的节点组成的二叉树, 树中每个节点的parent指针都正确地指向自己的父节点, 头节点的 parent指向空.
	/// 只给定在二叉树中的某个节点node, 该节点并不一定是头节点, 可能是树中任何一个节点, 请实现返回node的后继节点的函数.
	/// </summary>
	public class Node
	{
		public int value;
		public Node left;
		public Node right;
		public Node parent;
		public Node(int data)
		{
			this.value = data;
		}
	}

	/// <summary>
	/// 普通方法:
	/// 1. 通过node节 parent点的指针不断向上找到头节点
	/// 2. 通过找到的头节点, 做整棵树的中序遍历, 生成中序遍历序列.
	/// 3. 在中序遍历序列中, node节点的下一个节点, 就是其后续节点.
	/// 普通方法要遍历所有节点, 时间复杂度为O(N), 额外空间复杂度为O(N)
	/// </summary>
	class InorderSuccessorInBinarySearchTree
	{
		public Node InOrderSuccessor(Node root, Node n)
		{
			// Implement it later.
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// 最优解法:
	/// 如果node节点和node后继节点之间的实际距离为L, 最优解法只用走过L个节点, 时间复杂度为O(L), 额外空间复杂度为O(1)
	/// 情况一: 如果node有右子树, 那么后继节点就是右子树上最左边的节点.
	/// 情况二: 如果node没有右子树, 那么先看node是不是node父节点的左孩子, 如果是左孩子, 那么此时node的父节点就是node的后继节点.
	/// 如果是右孩子, 就向上寻找node的后继节点, 假设向上移动到的节点记为s, s的父节点记为p, 如果发现s是p的左孩子,
	/// 那么节点p就是node节点的后继节点, 否则就一直向上移动.
	/// 情况三: 如果一直向上寻找, 都移动到空节点了, 还没有发现node的后继节点, 说明node根本不存在后继节点, 返回空即可.
	/// </summary>
	class InorderSuccessorInBinarySearchTree2
	{
		public Node InOrderSuccessor(Node root, Node n)
		{
			if (n == null)
				return null;

			if (n.right != null)
				return MinNode(n.right);

			Node p = n.parent;

			while (p != null && p.right == n)
			{
				n = p;
				p = p.parent;
			}
			return p;
		}

		private Node MinNode(Node node)
		{
			if (node == null)
				return null;

			Node cur = node;
			while (cur.left != null)
				cur = cur.left;
			return cur;
		}

	}
}

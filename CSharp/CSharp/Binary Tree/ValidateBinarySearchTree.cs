using System.Collections.Generic;

namespace CSharp.Binary_Tree
{
	/// <summary>
	/// 搜索二叉树(二分搜索树)
	/// 每棵子树的头节点的值都比各自左子树的所有节点值要大,也都比各自右子树上所有节点值要小.
	///        4
	///     /     \
	///    2       6
	///  /   \   /   \
	/// 1     3 5     7
	/// 搜索二叉树按中序遍历得到的序列一定是从小到大排列的
	/// 红黑树, 平衡搜索二叉树(AVL树)等, 其实都是搜索二叉树的不同实现
	/// </summary>
	class ValidateBinarySearchTree
	{
		public bool IsValidBST(TreeNode root)
		{
			if (root == null)
				return true;

			Stack<TreeNode> stack = new Stack<TreeNode>();
			List<int> values = new List<int>();
			TreeNode cur = root;

			while (cur != null || stack.Count != 0)
			{
				if (cur != null)
				{
					stack.Push(cur);
					cur = cur.left;
				}
				else
				{
					cur = stack.Pop();
					values.Add(cur.val);
					cur = cur.right;
				}
			}

			for (int i = 1; i < values.Count; i++)
				if (values[i] <= values[i - 1])
					return false;
			return true;
		}
	}
}

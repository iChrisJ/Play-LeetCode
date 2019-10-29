using System.Collections.Generic;

namespace LeetCodeInCS.Binary_Tree
{
	/// <summary>
	/// 题: 一棵二叉树原本是搜索二叉树，但是其中有两个节点调换了位，使得这二叉树不再是搜索二叉树，请找到这两个错误节点。
	/// 1. 对二叉树进行中序遍历，依次出现的节点值会一直升序，如果两个节点值错了，会出现降序
	/// 2. 如果在中序遍历时节点值出现了两次降序，第一个错误的节点为第一次降序时较大的节点，第二个错误的节点为第二次降序时较小的节点
	/// 3. 如果在中序遍历时节点值只出现一次降序，第一个错误的节点为这次降序时较大的节点，第二个错误的节点为这次降序时较小的节点。
	/// </summary>
	class FindWrongNodes
	{
		public IList<TreeNode> FindTheWrongNodes(TreeNode root)
		{
			IList<TreeNode> res = new List<TreeNode>();
			if (root == null || (root.left == null && root.right == null))
				return res;

			List<TreeNode> list = new List<TreeNode>();
			InorderTraverse(root, list);
			int firstLargeIndex = -1;

			for (int i = 0; i < list.Count - 1; i++)
			{
				if (list[i].val > list[i + 1].val)
				{
					firstLargeIndex = firstLargeIndex == -1 ? i : firstLargeIndex;
					res.Add(list[i]);
				}
			}

			if (res.Count == 1)
				res.Add(list[firstLargeIndex + 1]);
			return res;
		}

		private void InorderTraverse(TreeNode node, IList<TreeNode> list)
		{
			if (node == null)
				return;
			InorderTraverse(node.left, list);
			list.Add(node);
			InorderTraverse(node.right, list);
		}
	}
}

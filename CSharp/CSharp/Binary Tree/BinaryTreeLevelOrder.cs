using System.Collections.Generic;

namespace LeetCodeInCS.Binary_Tree
{
	/// <summary>
	/// 给定一棵二叉树的头节点root, 请按照图示格式打印
	///     1
	///    / \
	///	  2   3
	///  /   / \
	/// 4   5   6
	///    / \
	///   7   8
	/// 返回:
	/// 1
	/// 2 3
	/// 4 5 6
	/// 7 8
	/// </summary>
	class BinaryTreeLevelOrder_Solution
	{
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			IList<IList<int>> res = new List<IList<int>>();
			Queue<TreeNode> queue = new Queue<TreeNode>();

			if (root != null)
				queue.Enqueue(root);
			while (queue.Count != 0)
			{
				int levelCount = queue.Count;
				IList<int> nodes = new List<int>();
				for (int i = 0; i < levelCount; i++)
				{
					TreeNode node = queue.Dequeue();
					if (node.left != null)
						queue.Enqueue(node.left);
					if (node.right != null)
						queue.Enqueue(node.right);
					nodes.Add(node.val);
				}
				res.Add(nodes);
			}
			return res;
		}
	}
}

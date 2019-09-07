using System;

namespace CSharp.Binary_Tree
{
	/// <summary>
	/// 给定一棵二叉树的头节点head，已知其中所有节点的值都不一样，找到含有节点最多的搜索二叉子树，并返回这棵子树的头节点。
	/// 例如，大家现在看到的图1这棵树，最大搜索子树就是图2这棵树
	///              6                           10
	///       /             \                  /    \
	///      1              12                4     14
	///  /       \      /       \            / \    / \
	/// 0         7    10       13          2   5  11 15
	///               /   \   /   \
	///              4    14 20   16
	///             / \   / \
	///            2   5 11 15
	/// 
	/// 以节点node为头的树中，最大的搜索二叉子树只可能来自以下两种情况：
	/// 1. 来自node左子树上的最大搜索二叉子树是以node左孩子为头的，并且来自node右子树上的最大搜索二叉子树是以node右孩子为头的，
	/// node左子树上的最大搜索二叉子树的最大值小于node的节点值，node右子树上的最大搜索二叉子树的最小值大于node的节点值，
	/// 那么以节点node为头的整棵树都是搜索二叉树。
	/// 2. 如果不满足第一种情况，说明以节点node为头的树整体不能连成搜索二叉树。这种情况下，
	/// 以node为头的树上的最大搜索二叉子树是来自node的左子树上的最大搜索二叉子树和来自node的右子树上的最大搜索二叉子树之间，
	/// 节点数较多的那个。
	/// 
	/// 通过以上分析求解的具体过程如下：
	/// 1. 整体过程是二叉树的后序遍历。
	/// 2. 遍历到当前节点记为cur时，先遍历cur的左子树并收集4个信息，分别是左子树上，最大搜索二叉子树的头节点记、节点数、树上最小值和树上最大值。
	/// 再遍历cur的右子树收集4个信息，分别是右子树上最大搜索二叉子树的头节点、节点数、最小值和最大值。
	/// 3. 根据步骤2所收集的信息，判断是否满足第一种情况，也就是是否以cur为头的子树，整体都是搜索二叉树。如果满足第一种情况，就返回cur节点，
	/// 如果满足第二种情况，就返回左子树和右子树各自的最大搜索二叉树中，节点数较多的那个树的头节点。
	/// 4. 对于如何返回4个信息，可以使用全局变量更新的方式实现。
	/// </summary>
	class LargestBSTSubtree
	{
		private Data maxData;

		public TreeNode FindLargestBSTSubtree(TreeNode root)
		{
			if (root == null)
				return root;

			GetLargestSubtreeData(root);
			return maxData.Head;

		}

		private Data GetLargestSubtreeData(TreeNode node)
		{
			Data cur = new Data();

			if (node == null)
			{
				cur.IsBST = true;
				return cur;
			}
			cur.Head = node;

			Data left = GetLargestSubtreeData(node.left);
			Data right = GetLargestSubtreeData(node.right);

			cur.MinValue = Math.Min(node.val, Math.Min(left.MinValue, right.MinValue));
			cur.MaxValue = Math.Max(node.val, Math.Max(left.MaxValue, right.MaxValue));

			if (left.IsBST && right.IsBST && left.MaxValue < node.val && right.MinValue > node.val)
			{
				cur.IsBST = true;
				cur.Count = left.Count + right.Count + 1;
				if (maxData == null || maxData.Count < cur.Count)
					maxData = cur;
			}
			else
				cur.Count = 0;

			return cur;
		}

		private class Data
		{
			public TreeNode Head { get; set; }
			public int Count { get; set; }
			public int MinValue { get; set; }
			public int MaxValue { get; set; }
			public bool IsBST { get; set; }

			public Data()
			{
				Count = 0;
				MinValue = int.MaxValue;
				MaxValue = int.MinValue;
				IsBST = false;
			}
		}
	}
}

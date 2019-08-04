using System.Collections.Generic;

namespace CSharp._0199_Binary_Tree_Right_Side_View
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
		public IList<int> RightSideView(TreeNode root)
		{
			IList<IList<int>> levelOrderList = new List<IList<int>>();
			Queue<TreeNode> queue = new Queue<TreeNode>();

			if (root != null)
				queue.Enqueue(root);
			while (queue.Count != 0)
			{
				int levelNodeCount = queue.Count;
				IList<int> nodes = new List<int>();
				for (int i = 0; i < levelNodeCount; i++)
				{
					TreeNode front = queue.Dequeue();
					if (front.left != null)
						queue.Enqueue(front.left);
					if (front.right != null)
						queue.Enqueue(front.right);
					nodes.Add(front.val);
				}
				levelOrderList.Add(nodes);
			}

			IList<int> res = new List<int>();
			for (int i = 0; i < levelOrderList.Count; i++)
				res.Add(levelOrderList[i][levelOrderList[i].Count - 1]);
			return res;
		}
	}
}

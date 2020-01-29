using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0297_Serialize_and_Deserialize_Binary_Tree
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Codec
	{
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			StringBuilder res = new StringBuilder();

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				TreeNode front = queue.Dequeue();

				if (front == null)
					res.Append("null");
				else
				{
					res.Append($"{front.val}");
					queue.Enqueue(front.left);
					queue.Enqueue(front.right);
				}

				if (queue.Count > 0)
					res.Append(",");
			}
			return res.ToString();
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			if (data == null || data.Length == 0)
				return null;

			string[] vals = data.Split(',');

			int index = 0;
			TreeNode root = vals[index++] == "null" ? null : new TreeNode(int.Parse(vals[index - 1]));

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				TreeNode front = queue.Dequeue();
				if (front != null)
				{
					front.left = vals[index++] == "null" ? null : new TreeNode(int.Parse(vals[index - 1]));
					front.right = vals[index++] == "null" ? null : new TreeNode(int.Parse(vals[index - 1]));
					queue.Enqueue(front.left);
					queue.Enqueue(front.right);
				}
			}
			return root;
		}
	}
}

using System.Collections.Generic;

namespace CSharp.Binary_Tree
{
	/// <summary>
	/// 1. 假设序列化结果为str, 初始时str为空字符串. 
	/// 2. 先序遍历二叉树时如果遇到空节点, 在str末尾加上"#!"
	/// 3. 如果遇到不为空的节点，假设节点值为3，就在str的末尾加上"3!"
	/// </summary>
	public class PreOrder_Codec
	{
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			if (root == null)
				return "#!";

			string res = root.val + "!";
			res += serialize(root.left);
			res += serialize(root.right);
			return res;
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			if (data == null || data.Length == 0)
				return null;
			string[] values = data.Split("!");
			if (values.Length == 0 || values[0] == "#")
				return null;

			Queue<string> queue = new Queue<string>(values);
			return DeserializePreOrder(queue);
		}

		private TreeNode DeserializePreOrder(Queue<string> q)
		{
			string val = q.Dequeue();
			if (val == "#")
				return null;
			TreeNode node = new TreeNode(int.Parse(val));
			node.left = DeserializePreOrder(q);
			node.right = DeserializePreOrder(q);
			return node;
		}
	}

	public class PostOrder_Codec
	{
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			if (root == null)
				return "#!";
			string res = string.Empty;
			res += serialize(root.left);
			res += serialize(root.right);
			res += root.val + "!";

			return res;
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			if (data == null || data.Length == 0)
				return null;
			string[] values = data.Split("!");
			if (values.Length == 0)
				return null;

			Stack<string> stack = new Stack<string>(values);

			if (string.IsNullOrEmpty(stack.Peek())) // Remove blank string.
				stack.Pop();
			return DeserializePostOrder(stack);
		}

		private TreeNode DeserializePostOrder(Stack<string> s)
		{
			string val = s.Pop();
			if (val == "#")
				return null;

			TreeNode node = new TreeNode(int.Parse(val));
			node.right = DeserializePostOrder(s);
			node.left = DeserializePostOrder(s);

			return node;
		}
	}

	/// <summary>
	/// 按层遍历的方式对二叉树进行序列化
	/// 1. 用队列来进行二叉树的按层遍历, 即宽度优先遍历.
	/// 2. 除了访问节点的顺序是按层遍历之外, 对结果字符串的处理,与之前介绍的处理方式一样.
	/// 3. 反序列化过程同理
	/// </summary>
	public class LevelOrder_Codec
	{
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			if (root == null)
				return "#!";

			string res = root.val + "!";
			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count != 0)
			{
				TreeNode node = queue.Dequeue();
				if (node.left != null)
				{
					res += node.left.val + "!";
					queue.Enqueue(node.left);
				}
				else
					res += "#!";

				if (node.right != null)
				{
					res += node.right.val + "!";
					queue.Enqueue(node.right);
				}
				else
					res += "#!";
			}
			return res;
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			if (data == null || data.Length == 0)
				return null;
			string[] values = data.Split("!");

			if (values.Length == 0 || values[0] == "#")
				return null;

			int index = 0;
			Queue<TreeNode> queue = new Queue<TreeNode>();
			TreeNode head = new TreeNode(int.Parse(values[index]));
			index++;
			queue.Enqueue(head);

			while (queue.Count != 0)
			{
				TreeNode node = queue.Dequeue();
				node.left = values[index] == "#" ? null : new TreeNode(int.Parse(values[index]));
				index++;
				node.right = values[index] == "#" ? null : new TreeNode(int.Parse(values[index]));
				index++;

				if (node.left != null)
					queue.Enqueue(node.left);
				if (node.right != null)
					queue.Enqueue(node.right);
			}
			return head;
		}
	}
}

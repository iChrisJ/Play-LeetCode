using System.Collections.Generic;

namespace CSharp._0677_Map_Sum_Pairs
{
	public class MapSum
	{
		private class Node
		{
			public int Value { get; set; }
			public IDictionary<char, Node> Next { get; private set; }

			public Node(int value)
			{
				Value = value;
				Next = new Dictionary<char, Node>();
			}

			public Node() : this(0) { }
		}

		private Node root;

		/** Initialize your data structure here. */
		public MapSum()
		{
			root = new Node();
		}

		public void Insert(string key, int val)
		{
			Node cur = root;
			for (int i = 0; i < key.Length; i++)
			{
				if (!cur.Next.ContainsKey(key[i]))
					cur.Next.Add(key[i], new Node());
				cur = cur.Next[key[i]];
			}
			cur.Value = val;
		}

		public int Sum(string prefix)
		{
			Node cur = root;
			for (int i = 0; i < prefix.Length; i++)
			{
				if (!cur.Next.ContainsKey(prefix[i]))
					return 0;
				cur = cur.Next[prefix[i]];
			}

			return Sum(cur);
		}

		private int Sum(Node node)
		{
			int res = node.Value;

			foreach (char key in node.Next.Keys)
				res += Sum(node.Next[key]);
			return res;
		}
	}
}

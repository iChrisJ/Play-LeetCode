using System.Collections.Generic;

namespace LeetCodeInCS._0208_Implement_Trie__Prefix_Tree_
{
	public class Trie
	{
		private class TrieNode
		{
			public char Value { get; private set; }
			public bool IsWord { get; set; }
			public TrieNode[] Children { get; private set; }
			public TrieNode()
			{
				Children = new TrieNode[26];
			}

			public TrieNode(char val)
			{
				Value = val;
				Children = new TrieNode[26];
			}
		}

		private TrieNode root;
		/** Initialize your data structure here. */
		public Trie()
		{
			root = new TrieNode(' ');
		}

		/** Inserts a word into the trie. */
		public void Insert(string word)
		{
			TrieNode node = root;

			foreach (char c in word)
			{
				if (node.Children[c - 'a'] == null)
					node.Children[c - 'a'] = new TrieNode(c);
				node = node.Children[c - 'a'];
			}
			node.IsWord = true;
		}

		/** Returns if the word is in the trie. */
		public bool Search(string word)
		{
			TrieNode node = root;
			foreach (char c in word)
			{
				if (node.Children[c - 'a'] == null)
					return false;
				node = node.Children[c - 'a'];
			}
			return node.IsWord;
		}

		/** Returns if there is any word in the trie that starts with the given prefix. */
		public bool StartsWith(string prefix)
		{
			TrieNode node = root;
			foreach (char c in prefix)
			{
				if (node.Children[c - 'a'] == null)
					return false;
				node = node.Children[c - 'a'];
			}
			return true;
		}
	}

	public class Trie2
	{
		private class Node
		{
			public bool IsWord { get; set; }
			public IDictionary<char, Node> Next { get; private set; }

			public Node(bool isWord)
			{
				IsWord = isWord;
				Next = new Dictionary<char, Node>();
			}

			public Node() : this(false) { }
		}

		private Node root;

		/** Initialize your data structure here. */
		public Trie2()
		{
			root = new Node();
		}

		/** Inserts a word into the trie. */
		public void Insert(string word)
		{
			Node cur = root;
			for (int i = 0; i < word.Length; i++)
			{
				if (!cur.Next.ContainsKey(word[i]))
					cur.Next.Add(word[i], new Node());
				cur = cur.Next[word[i]];
			}

			if (!cur.IsWord)
				cur.IsWord = true;
		}

		/** Returns if the word is in the trie. */
		public bool Search(string word)
		{
			Node cur = root;
			for (int i = 0; i < word.Length; i++)
			{
				if (!cur.Next.ContainsKey(word[i]))
					return false;
				cur = cur.Next[word[i]];
			}
			return cur.IsWord;
		}

		/** Returns if there is any word in the trie that starts with the given prefix. */
		public bool StartsWith(string prefix)
		{
			Node cur = root;
			for (int i = 0; i < prefix.Length; i++)
			{
				if (!cur.Next.ContainsKey(prefix[i]))
					return false;
				cur = cur.Next[prefix[i]];
			}
			return true;
		}
	}
}

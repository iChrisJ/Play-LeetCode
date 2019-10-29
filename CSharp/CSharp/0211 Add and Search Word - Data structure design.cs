using System.Collections.Generic;

namespace LeetCodeInCS._0211_Add_and_Search_Word___Data_structure_design
{
	public class WordDictionary
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
		public WordDictionary()
		{
			root = new TrieNode(' ');
		}

		/** Adds a word into the data structure. */
		public void AddWord(string word)
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

		/** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
		public bool Search(string word)
		{
			if (word == null || word.Length == 0)
				return false;
			return Find(word, root);
		}

		private bool Find(string word, TrieNode node)
		{
			for (int i = 0; i < word.Length; i++)
			{
				if (word[i] != '.')
				{
					if (node.Children[word[i] - 'a'] == null)
						return false;
					node = node.Children[word[i] - 'a'];
				}
				else
				{
					for (int j = 0; j < node.Children.Length; j++)
					{
						if (node.Children[j] != null && ((i == word.Length - 1 && node.Children[j].IsWord) || Find(word.Substring(i + 1), node.Children[j]))) //DFS recursive
							return true;
					}
					return false;
				}
			}
			return node.IsWord;
		}
	}

	public class WordDictionary2
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
		public WordDictionary2()
		{
			root = new Node();
		}

		/** Adds a word into the data structure. */
		public void AddWord(string word)
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

		/** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
		public bool Search(string word)
		{
			return Match(root, word, 0);
		}

		private bool Match(Node node, string word, int index)
		{
			if (index == word.Length)
				return node.IsWord;

			if (word[index] != '.')
				return node.Next.ContainsKey(word[index])
					? Match(node.Next[word[index]], word, index + 1) : false;
			else
			{
				foreach (char key in node.Next.Keys)
				{
					if (Match(node.Next[key], word, index + 1))
						return true;
				}
				return false;
			}
		}
	}
}

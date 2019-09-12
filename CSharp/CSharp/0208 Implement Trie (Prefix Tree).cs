namespace CSharp._0208_Implement_Trie__Prefix_Tree_
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
}

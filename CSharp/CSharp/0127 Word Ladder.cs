using System.Collections.Generic;

namespace LeetCodeInCS._0127_Word_Ladder
{
	// TODO: Reduce time complexity.
	public class Solution
	{
		public int LadderLength(string beginWord, string endWord, IList<string> wordList)
		{
			if (wordList == null || wordList.Count == 0)
				return 0;

			Dictionary<string, HashSet<string>> dict = GetWordDict(beginWord, endWord, wordList);
			HashSet<string> visited = new HashSet<string> { beginWord };
			int trans_time = 0;

			Queue<string> queue = new Queue<string>();
			queue.Enqueue(beginWord);
			while (queue.Count > 0)
			{
				trans_time++;
				int len = queue.Count;
				while ((len--) > 0)
				{
					string frnt = queue.Dequeue();
					if (frnt == endWord)
						return trans_time;

					HashSet<string> val_list = dict[frnt];
					foreach (string val in val_list)
						if (visited.Add(val))
							queue.Enqueue(val);
				}
			}
			return 0;
		}

		private Dictionary<string, HashSet<string>> GetWordDict(string beginWord, string endWord, IList<string> wordList)
		{
			Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
			List<string> list = new List<string> { beginWord };
			list.AddRange(wordList);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == endWord || dict.ContainsKey(list[i]))
					continue;

				HashSet<string> val_set = new HashSet<string>();
				for (int j = 0; j < list.Count; j++)
				{
					if (IsOneCharDiff(list[i], list[j]))
						val_set.Add(list[j]);
				}
				dict.Add(list[i], val_set);
			}
			return dict;
		}

		private bool IsOneCharDiff(string key, string val)
		{
			if (key == null || val == null || key.Length != val.Length || key == val)
				return false;

			int diff_Count = 0;
			for (int i = 0; i < key.Length; i++)
			{
				if (key[i] != val[i])
					diff_Count++;
			}
			return diff_Count == 1;
		}

		public class Solution2
		{
			public int LadderLength(string beginWord, string endWord, IList<string> wordList)
			{
				if (wordList == null || wordList.Count == 0)
					return 0;

				HashSet<string> set = new HashSet<string>(wordList);
				if (!set.Contains(endWord))
					return 0;

				int step = 0;
				HashSet<string> visited = new HashSet<string> { beginWord };
				Queue<string> queue = new Queue<string>();
				queue.Enqueue(beginWord);

				while (queue.Count > 0)
				{
					step++;
					int len = queue.Count;
					while ((len--) > 0)
					{
						string frnt = queue.Dequeue();
						if (frnt == endWord)
							return step;

						for (int i = 0; i < frnt.Length; i++)
						{
							for (char j = 'a'; j <= 'z'; j++)
							{
								if (j == frnt[i])
									continue;
								string updated = $"{frnt.Substring(0, i)}{j}{frnt.Substring(i + 1)}";

								// one optimization
								if (updated == endWord)
									return step + 1;

								if (set.Contains(updated) && visited.Add(updated))
									queue.Enqueue(updated);
							}
						}
					}
				}
				return 0;
			}
		}
	}
}


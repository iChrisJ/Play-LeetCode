using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0126_Word_Ladder_II
{
	// TODO: Reduce time complexity.
	public class Solution
	{
		private IList<IList<string>> res;
		private int minStep = int.MaxValue;
		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
		{
			res = new List<IList<string>>();
			if (wordList == null || wordList.Count == 0)
				return res;

			HashSet<string> set = new HashSet<string>(wordList);
			if (!set.Contains(endWord))
				return res;

			Dictionary<string, HashSet<string>> dict = GetWordDict(beginWord, endWord, set);
			HashSet<string> visited = new HashSet<string> { beginWord };
			DFS(beginWord, endWord, dict, visited, new List<string> { beginWord }, 0);

			IList<IList<string>> ans = new List<IList<string>>();
			foreach (IList<string> path in res)
			{
				if (path.Count == minStep)
					ans.Add(path);
			}
			return ans;
		}

		private void DFS(string curWord, string endWord, Dictionary<string, HashSet<string>> dict, HashSet<string> visited, IList<string> path, int step)
		{
			if (curWord == endWord)
			{
				minStep = Math.Min(minStep, step);
				if (step == minStep)
					res.Add(new List<string>(path));
				return;
			}

			HashSet<string> vals = dict[curWord];
			foreach (string val in vals)
			{
				if (!visited.Contains(val))
				{
					visited.Add(val);
					path.Add(val);
					DFS(val, endWord, dict, visited, path, step + 1);
					visited.Remove(val);
					path.RemoveAt(path.Count - 1);
				}
			}
		}

		private Dictionary<string, HashSet<string>> GetWordDict(string beginWord, string endWord, HashSet<string> set)
		{
			Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
			List<string> list = new List<string> { beginWord };
			list.AddRange(set);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == endWord || dict.ContainsKey(list[i]))
					continue;

				HashSet<string> val_set = new HashSet<string>();

				for (int j = 0; j < list[i].Length; j++)
				{
					if (list[i] == endWord)
						continue;
					for (char k = 'a'; k < 'z'; k++)
					{
						if (k == list[i][j])
							continue;

						string updated = $"{list[i].Substring(0, j)}{k}{list[i].Substring(j + 1)}";
						if (set.Contains(updated))
							val_set.Add(updated);
					}
				}
				dict.Add(list[i], val_set);
			}
			return dict;
		}
	}
}

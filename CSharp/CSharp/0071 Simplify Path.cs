using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0071_Simplify_Path
{
	public class Solution
	{
		public string SimplifyPath(string path)
		{
			if (path == null || path.Length == 0)
				return "/";

			string[] folders = path.Split('/');
			Stack<string> stack = new Stack<string>();

			foreach (string folder in folders)
			{
				if (folder == "..")
				{
					if (stack.Count > 0)
						stack.Pop();
				}
				else if (folder == "." || string.IsNullOrEmpty(folder))
					continue;
				else
					stack.Push(folder);
			}

			StringBuilder res = new StringBuilder();
			while (stack.Count > 0)
				res.Insert(0, $"/{stack.Pop()}");

			return res.Length == 0 ? "/" : res.ToString();
		}
	}
}

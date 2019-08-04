using System.Collections.Generic;

namespace CSharp._0071_Simplify_Path
{
	public class Solution
	{
		public string SimplifyPath(string path)
		{
			string[] paths = path.Split("/");
			Stack<string> pathStack = new Stack<string>();

			for (int i = 0; i < paths.Length; i++)
			{
				if (paths[i] == "." || string.IsNullOrEmpty(paths[i]) || (paths[i] == ".." && pathStack.Count == 0))
					continue;
				else if (paths[i] == ".." && pathStack.Count > 0)
					pathStack.Pop();
				else
					pathStack.Push(paths[i]);
			}

			string res = pathStack.Count == 0 ? string.Empty : pathStack.Pop();
			while (pathStack.Count != 0)
			{
				res = pathStack.Pop() + "/" + res;
			}
			return "/" + res;
		}

		//public static void Main(string[] args)
		//{
		//	var a = new Solution().SimplifyPath("/../");
		//}
	}
}

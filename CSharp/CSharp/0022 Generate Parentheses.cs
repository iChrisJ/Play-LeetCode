using System.Collections.Generic;

namespace CSharp._0022_Generate_Parentheses
{
	public class Solution
	{
		private IList<string> result;
		public IList<string> GenerateParenthesis(int n)
		{
			result = new List<string>();
			CombineParenthesis(n, n, string.Empty);
			return result;
		}

		private void CombineParenthesis(int left, int right, string res)
		{
			if (left == 0 && right == 0)
			{
				result.Add(res);
				return;
			}

			if (left > 0)
				CombineParenthesis(left - 1, right, res + "(");
			if (right > left)
				CombineParenthesis(left, right - 1, res + ")");
		}
	}
}

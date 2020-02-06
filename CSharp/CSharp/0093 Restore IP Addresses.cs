using System.Collections.Generic;

namespace LeetCodeInCS._0093_Restore_IP_Addresses
{
	public class Solution
	{
		private IList<string> res;

		public IList<string> RestoreIpAddresses(string s)
		{
			res = new List<string>();
			if (s == null || s.Length < 4 || s.Length > 12)
				return res;
			BuildIPAddresses(string.Empty, s, 0);
			return res;
		}

		private void BuildIPAddresses(string begin, string rest, int dotCount)
		{
			if (dotCount == 3)
			{
				if (rest.Length == 0 || (rest.Length > 1 && rest[0] == '0') || int.Parse(rest) > 255)
					return;
				res.Add($"{begin}{rest}");
				return;
			}

			for (int i = 1; i <= 3 && i <= rest.Length; i++)
			{
				string segment = rest.Substring(0, i);
				if (segment.Length > 1 && segment[0] == '0') // 剪枝
					return;

				if (int.Parse(segment) <= 255)
					BuildIPAddresses($"{begin}{segment}.", rest.Substring(i), dotCount + 1);
			}
		}
	}
}

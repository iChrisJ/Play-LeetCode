using System.Collections.Generic;

namespace LeetCodeInCS._0093_Restore_IP_Addresses
{
	public class Solution
	{

		public IList<string> Result { get; private set; }

		public IList<string> RestoreIpAddresses(string s)
		{
			Result = new List<string>();
			GetValidIPs(string.Empty, s, 0);
			return Result;
		}

		private void GetValidIPs(string first, string rest, int dotCount)
		{
			if (dotCount == 3)
			{
				if (rest.Length > 1 && rest[0] == '0')
					return;
				if (rest.Length > 0 && int.Parse(rest) <= 255)
					Result.Add(first + rest);
				return;
			}

			for (int i = 1; i <= 3 && i <= rest.Length; i++)
			{
				string cur = rest.Substring(0, i);
				if (cur.Length > 1 && cur[0] == '0')
					return;

				if (int.Parse(cur) <= 255 || (int.Parse(cur) == 0 && cur.Length == 1))
					GetValidIPs(first + cur + ".", rest.Substring(i), dotCount + 1);
			}
		}

		//public static void Main(string[] args)
		//{
		//	var a = new Solution().RestoreIpAddresses("010010");
		//}
	}
}

using System.Collections.Generic;

namespace CSharp._0401_Binary_Watch
{
	public class Solution
	{
		public IList<string> Result { get; set; }

		private int[] arr = new int[10] { 1, 2, 4, 8, 16, 32, 1, 2, 4, 8 };
		public IList<string> ReadBinaryWatch(int num)
		{
			Result = new List<string>();
			if (num < 0)
				return Result;
			GetTime(num, 0, 0, 0);
			return Result;
		}

		private void GetTime(int num, int start, int totalmin, int totalhour)
		{
			if (totalmin >= 60 || totalhour >= 12)
				return;

			if (num == 0)
			{
				Result.Add(GetTimeFromBinary(totalmin, totalhour));
				return;
			}

			for (int i = start; i < arr.Length; i++)
			{
				if (num > 0)
				{
					if (i < 6)
					{
						totalmin += arr[i];
					}
					else
					{
						totalhour += arr[i];
					}

					GetTime(num - 1, i + 1, totalmin, totalhour);
					if (i < 6)
					{
						totalmin -= arr[i];
					}
					else
					{
						totalhour -= arr[i];
					}
				}
			}
		}

		private string GetTimeFromBinary(int min, int hour)
		{
			int m = min % 60;
			return m < 10 ? $"{hour}:0{m}" : $"{hour}:{m}";
		}
	}
}

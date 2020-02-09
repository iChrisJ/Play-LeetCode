using System.Collections.Generic;

namespace LeetCodeInCS._0401_Binary_Watch
{
	public class Solution
	{
		private IList<string> res;
		private int[] time_map;
		public IList<string> ReadBinaryWatch(int num)
		{
			res = new List<string>();
			if (num < 0)
				return res;
			time_map = new int[10] { 1, 2, 4, 8, 16, 32, 1, 2, 4, 8 };
			GetTime(num, 0, 0, 0);
			return res;
		}

		private void GetTime(int num, int start, int total_mins, int total_hours)
		{
			if (total_mins >= 60 || total_hours >= 12)
				return;

			if (num == 0)
			{
				res.Add(ConvertToTime(total_mins, total_hours));
				return;
			}

			for (int i = start; i < time_map.Length; i++)
			{
				if (num > 0)
				{
					if (i < 6)
						total_mins += time_map[i];
					else
						total_hours += time_map[i];

					GetTime(num - 1, i + 1, total_mins, total_hours);

					if (i < 6)
						total_mins -= time_map[i];
					else
						total_hours -= time_map[i];
				}
			}
		}

		private string ConvertToTime(int total_mins, int total_hours)
		{
			total_mins = total_mins % 60;
			return total_mins < 10 ? $"{total_hours}:0{total_mins}" : $"{total_hours}:{total_mins}";
		}
	}
}

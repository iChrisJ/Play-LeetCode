using System;

namespace CSharp._0744_Find_Smallest_Letter_Greater_Than_Target
{
	public class Solution
	{
		public char NextGreatestLetter(char[] letters, char target)
		{
			if (letters == null || letters.Length == 0)
				throw new Exception("Incorrect input!");

			int l = 0, r = letters.Length - 1;
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (letters[mid] == target)
				{
					if (mid == letters.Length - 1)
						return letters[0];
					l = mid + 1;
					break;
				}
				else if (letters[mid] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}

			if (l == letters.Length)
				return letters[0];
			while (l < letters.Length && letters[l] == target)
				l++;
			return l == letters.Length ? letters[0] : letters[l];
		}
	}
}

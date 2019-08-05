namespace CSharp._0066_Plus_One
{
	public class Solution
	{
		public int[] PlusOne(int[] digits)
		{
			bool isAllNine = true;
			for (int i = 0; i < digits.Length; i++)
			{
				if (digits[i] != 9)
					isAllNine = false;
			}

			int[] res = new int[isAllNine ? digits.Length + 1 : digits.Length];

			bool isCarried = true;
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				int j = isAllNine ? i + 1 : i;
				int temp = isCarried ? digits[i] + 1 : digits[i];
				res[j] = temp > 9 ? temp % 10 : temp;
				isCarried = temp > 9;
			}

			if (isCarried)
				res[0] = 1;
			return res;
		}
	}
}

namespace CSharp._0441_Arranging_Coins
{
	public class Solution
	{
		public int ArrangeCoins(int n)
		{
			if (n <= 0)
				return 0;

			long l = 1, r = n;
			while (l <= r)
			{
				long i = l + (r - l) / 2;

				if ((i + 1) * i / 2 <= n && (i + 1 + 1) * (i + 1) / 2 > n)
					return (int)i;
				else if ((i + 1) * i / 2 > n)
					r = i - 1;
				else
					l = i + 1;
			}
			return (int)l;
		}
	}
}

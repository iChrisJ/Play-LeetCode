namespace LeetCodeInCS._0134_Gas_Station
{
	public class Solution
	{
		/// Time: O(n^2)
		public int CanCompleteCircuit(int[] gas, int[] cost)
		{
			for (int i = 0; i < gas.Length; i++)
			{
				if (gas[i] >= cost[i])
				{
					int rest = 0;
					int j = i;
					for (; j < i + gas.Length; j++)
					{
						rest += gas[j % gas.Length] - cost[j % cost.Length];
						if ((rest <= 0 && j < i + gas.Length - 1) || (rest < 0 && j == i + gas.Length - 1))
							break;
					}
					if (rest >= 0 && j == i + gas.Length)
						return i;
				}
			}
			return -1;
		}
	}

	public class Solution2
	{
		/// Time: O(n)
		public int CanCompleteCircuit(int[] gas, int[] cost)
		{
			int totalGas = 0;
			int totalCost = 0;
			int curRest = 0;
			int res = 0;

			for (int i = 0; i < gas.Length; i++)
			{
				totalGas += gas[i];
				totalCost += cost[i];
				curRest += gas[i] - cost[i];

				if (curRest < 0)
				{
					curRest = 0;
					res = i + 1;
				}
			}

			return totalGas < totalCost ? -1 : res;
		}
	}
}

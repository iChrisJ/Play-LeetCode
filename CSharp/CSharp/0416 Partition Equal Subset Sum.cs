namespace CSharp._0416_Partition_Equal_Subset_Sum
{
	public class Solution
	{
		public bool CanPartition(int[] nums)
		{
			int sum = 0;
			foreach (var num in nums)
				sum += num;

			if (sum % 2 > 0)
				return false;

			return TryPartition(nums, nums.Length - 1, sum / 2);
		}

		private bool TryPartition(int[] nums, int index, int C)
		{
			if (C == 0)
				return true;
			if (index < 0 || C < 0)
				return false;

			return TryPartition(nums, index - 1, C) || TryPartition(nums, index - 1, C - nums[index]);
		}
	}

	public class Solution2
	{
		private int[,] memo;
		public bool CanPartition(int[] nums)
		{
			int sum = 0;
			foreach (var num in nums)
				sum += num;

			if (sum % 2 > 0)
				return false;

			memo = new int[nums.Length, sum / 2 + 1];

			return TryPartition(nums, nums.Length - 1, sum / 2);
		}

		private bool TryPartition(int[] nums, int index, int C)
		{
			if (C == 0)
				return true;
			if (index < 0 || C < 0)
				return false;

			if (memo[index, C] != -1)
				return memo[index, C] == 2;

			memo[index, C] = (TryPartition(nums, index - 1, C) || TryPartition(nums, index - 1, C - nums[index])) == true ? 2 : 1;
			return memo[index, C] == 2;
		}

		//public static void Main()
		//{
		//	var res = new Solution2().CanPartition(new int[] { 1, 2, 5 });
		//}
	}

	public class Solution3
	{
		private bool[] memo;
		public bool CanPartition(int[] nums)
		{
			int sum = 0;
			foreach (var num in nums)
				sum += num;

			if (sum % 2 > 0)
				return false;

			int n = nums.Length;
			int C = sum / 2;
			memo = new bool[C + 1];

			for (int j = 0; j <= C; j++)
				memo[j] = nums[0] == j ? true : false;

			for (int i = 1; i < n; i++)
				for (int j = C; j >= nums[i]; j--)
					memo[j] = memo[j] || memo[j - nums[i]] ? true : false;

			return memo[C];
		}

		//public static void Main()
		//{
		//	var res = new Solution2().CanPartition(new int[] { 1, 2, 5 });
		//}
	}
}

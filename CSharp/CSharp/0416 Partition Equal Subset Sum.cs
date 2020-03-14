namespace LeetCodeInCS._0416_Partition_Equal_Subset_Sum
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
	}

	public class Solution3
	{
		public bool CanPartition(int[] nums)
		{
			int sum = 0;
			foreach (var num in nums)
				sum += num;

			if (sum % 2 > 0)
				return false;

			int C = sum / 2;
			bool[] dp = new bool[C + 1];
			if (C >= nums[0])
				dp[nums[0]] = true;

			for (int i = 1; i < nums.Length; i++)
				for (int j = C; j >= nums[i]; j--)
					dp[j] = dp[j] || dp[j - nums[i]];

			return dp[C];
		}
	}
}

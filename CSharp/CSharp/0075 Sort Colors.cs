namespace LeetCodeInCS._0075_Sort_Colors
{
	/// <summary>
	/// Counting sort.
	/// </summary>
	public class Solution
	{
		public void SortColors(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return;

			int[] count = new int[3];
			for (int i = 0; i < nums.Length; i++)
				count[nums[i]]++;

			int k = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < count[i]; j++)
					nums[k++] = i;
			}
		}
	}

	/// <summary>
	/// Quick Sort in 3 ways.
	/// </summary>
	public class Solution2
	{
		public void SortColors(int[] nums)
		{
			int lt = -1, gt = nums.Length, i = 0;
			while (i < gt)
			{
				int temp;
				switch (nums[i])
				{
					case 0:
						temp = nums[lt + 1];
						nums[lt + 1] = nums[i];
						nums[i] = temp;
						i++;
						lt++;
						break;
					case 1:
						i++;
						break;
					case 2:
						temp = nums[gt - 1];
						nums[gt - 1] = nums[i];
						nums[i] = temp;
						gt--;
						break;
				}
			}
		}
	}
}

namespace LeetCodeInCS._0075_Sort_Colors
{
	public class Solution
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

		public void SortColors2(int[] nums)
		{
			int[] count = new int[3] { 0, 0, 0 };

			for (int i = 0; i < nums.Length; i++)
				count[nums[i]]++;

			int index = 0;
			for (int i = 0; i < count[0]; i++)
				nums[index++] = 0;
			for (int i = 0; i < count[1]; i++)
				nums[index++] = 1;
			for (int i = 0; i < count[2]; i++)
				nums[index++] = 2;
		}
	}
}

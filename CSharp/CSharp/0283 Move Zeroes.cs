namespace CSharp._0283_Move_Zeroes
{
	public class Solution
	{
		public void MoveZeroes(int[] nums)
		{
			int k = 0; // In numns, [0...k) is non-zero element;
			for (int i = 0; i < nums.Length; i++)
				if (nums[i] != 0)
					nums[k++] = nums[i];

			for (int i = k; i < nums.Length; i++)
				nums[i] = 0;
		}

		public void MoveZeroes2(int[] nums)
		{
			int k = 0; // In numns, [0...k) is non-zero element;
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != 0)
				{
					if (i != k)
					{
						int temp = nums[i];
						nums[i] = nums[k];
						nums[k] = temp;
					}
					k++;
				}
			}
		}
	}
}

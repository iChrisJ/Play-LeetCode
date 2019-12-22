namespace LeetCodeInCS._0026_Remove_Duplicates_from_Sorted_Array
{
	public class Solution
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums == null || nums.Length < 2)
				return nums.Length;

			int len = 0; // [0..len] no dup elements.
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] != nums[len])
					if (i == len + 1)
						len++;
					else
						nums[++len] = nums[i];
				//if (nums[i] != nums[len] && i > ++len)
				//	nums[len] = nums[i];
			}
			return len + 1;
		}
	}
}

namespace CSharp._0026_Remove_Duplicates_from_Sorted_Array
{
	public class Solution
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			int j = 0, i = 1;
			while (i < nums.Length)
			{
				if (nums[i] > nums[j])
				{
					j++;
					nums[j] = nums[i];
				}
				i++;
			}
			return j + 1;
		}
	}
}

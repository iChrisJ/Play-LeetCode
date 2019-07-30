namespace CSharp._0027_Remove_Element
{
	public class Solution
	{
		/// <summary>
		/// Actually this problem is same as problem283
		/// </summary>
		public int RemoveElement(int[] nums, int val)
		{
			int k = 0; // [0, k) doesn't contains val
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != val)
				{
					if (i != k)
					{
						int temp = nums[k];
						nums[k] = nums[i];
						nums[i] = temp;
					}
					k++;
				}
			}
			return k;
		}
	}
}

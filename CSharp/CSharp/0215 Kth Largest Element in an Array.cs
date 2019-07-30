namespace CSharp._0215_Kth_Largest_Element_in_an_Array
{
	public class Solution
	{
		public int FindKthLargest(int[] nums, int k)
		{
			return FindKthElement(nums, 0, nums.Length - 1, nums.Length - k);
		}

		/// <summary>
		/// Find the pos-index(zero-based)element
		/// </summary>
		private int FindKthElement(int[] nums, int l, int r, int pos)
		{
			if (l == r)
				return nums[l];

			int p = Partition(nums, l, r);

			if (p == pos)
				return nums[p];
			else if (p > pos)
				return FindKthElement(nums, l, p - 1, pos);
			else // p < pos
				return FindKthElement(nums, p + 1, r, pos);
		}

		private int Partition(int[] nums, int l, int r)
		{
			int pos = l;

			int temp;
			for (int i = l + 1; i <= r; i++)
			{
				if (nums[i] < nums[l])
				{
					temp = nums[pos + 1];
					nums[pos + 1] = nums[i];
					nums[i] = temp;
					pos++;
				}
			}

			temp = nums[l];
			nums[l] = nums[pos];
			nums[pos] = temp;

			return pos;
		}
	}
}

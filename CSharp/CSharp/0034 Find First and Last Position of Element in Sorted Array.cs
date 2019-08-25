namespace CSharp._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
	public class Solution
	{
		public int[] SearchRange(int[] nums, int target)
		{
			if (nums == null || nums.Length == 0 || target < nums[0] || target > nums[nums.Length - 1])
				return new int[] { -1, -1 };

			int l = 0, r = nums.Length - 1;
			int first = -1, last = -1;

			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] == target)
				{
					if (mid == 0 || nums[mid - 1] < target)
						first = mid;
					else
						r = mid - 1;
				}
				else if (nums[mid] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}

			l = first == -1 ? 0 : first + 1; ;
			r = nums.Length - 1;

			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (nums[mid] == target)
				{
					if (mid == nums.Length - 1 || nums[mid + 1] > target)
						last = mid;
					else
						l = mid + 1;
				}
				else if (nums[mid] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}

			if (first == -1 && last == -1)
				return new int[] { -1, -1 };
			else if (first == -1 || last == -1)
				return new int[] { first == -1 ? last : first };
			else
				return new int[] { first, last };
		}
	}
}

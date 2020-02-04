namespace LeetCodeInCS._0108_Convert_Sorted_Array_to_Binary_Search_Tree
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		public TreeNode SortedArrayToBST(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return null;
			return SortedArrayToBST(nums, 0, nums.Length - 1);
		}

		private TreeNode SortedArrayToBST(int[] nums, int l, int r)
		{
			if (l > r)
				return null;

			int mid = l + (r - l) / 2;
			return new TreeNode(nums[mid])
			{
				left = SortedArrayToBST(nums, l, mid - 1),
				right = SortedArrayToBST(nums, mid + 1, r)
			};
		}
	}
}

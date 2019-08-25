namespace CSharp._0108_Convert_Sorted_Array_to_Binary_Search_Tree
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

			int mid = (nums.Length - 1) / 2;
			TreeNode root = new TreeNode(nums[mid]);
			root.left = GenerateTree(nums, 0, mid - 1);
			root.right = GenerateTree(nums, mid + 1, nums.Length - 1);
			return root;
		}

		private TreeNode GenerateTree(int[] list, int l, int r)
		{
			if (l > r)
				return null;
			int mid = l + (r - l) / 2;
			TreeNode node = new TreeNode(list[mid]);
			node.left = GenerateTree(list, l, mid - 1);
			node.right = GenerateTree(list, mid + 1, r);
			return node;
		}
	}
}

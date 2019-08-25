using System.Collections.Generic;

namespace CSharp._0109_Convert_Sorted_List_to_Binary_Search_Tree
{

	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Solution
	{
		public TreeNode SortedListToBST(ListNode head)
		{
			if (head == null)
				return null;

			List<int> list = new List<int>();
			while (head != null)
			{
				list.Add(head.val);
				head = head.next;
			}

			int mid = (list.Count - 1) / 2;
			TreeNode root = new TreeNode(list[mid]);
			root.left = GenerateTree(list, 0, mid - 1);
			root.right = GenerateTree(list, mid + 1, list.Count - 1);
			return root;
		}

		private TreeNode GenerateTree(List<int> list, int l, int r)
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

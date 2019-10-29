namespace LeetCodeInCS._0074_Search_a_2D_Matrix
{
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0)
				return false;

			int l = 0, r = matrix.Length - 1;
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (matrix[mid][0] == target)
					return true;
				else if (matrix[mid][0] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}

			int row = 0;
			if (r < 0)
				row = l;
			else if (l > matrix.Length - 1)
				row = r;
			else
				row = matrix[l][0] > target ? r : l;

			l = 0;
			r = matrix[row].Length - 1;
			while (l <= r)
			{
				int mid = l + (r - l) / 2;
				if (matrix[row][mid] == target)
					return true;
				else if (matrix[row][mid] > target)
					r = mid - 1;
				else
					l = mid + 1;
			}
			return false;
		}
	}
}

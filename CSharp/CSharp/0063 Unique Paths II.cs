namespace CSharp._0063_Unique_Paths_II
{
	public class Solution
	{
		/// Dynamic Programming
		/// Time Complexity: O(m*n)
		/// Space Complexity: O(1)
		public int UniquePathsWithObstacles(int[][] obstacleGrid)
		{
			if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0][0] == 1)
				return 0;

			obstacleGrid[0][0] = 1;

			for (int i = 1; i < obstacleGrid.Length; i++)
			{
				if (obstacleGrid[i][0] == 1)
					obstacleGrid[i][0] = 0;
				else // obstacleGrid[i][0] == 0
				{
					obstacleGrid[i][0] = obstacleGrid[i - 1][0];
				}
			}

			for (int i = 1; i < obstacleGrid[0].Length; i++)
			{
				if (obstacleGrid[0][i] == 1)
					obstacleGrid[0][i] = 0;
				else // obstacleGrid[0][i] == 0
				{
					obstacleGrid[0][i] = obstacleGrid[0][i - 1];
				}
			}

			for (int i = 1; i < obstacleGrid.Length; i++)
				for (int j = 1; j < obstacleGrid[i].Length; j++)
				{
					if (obstacleGrid[i][j] == 1)
						obstacleGrid[i][j] = 0;
					else
						obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
				}

			return obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[obstacleGrid.Length - 1].Length - 1];
		}

		//public static void Main()
		//{
		//	int[][] arr = new int[1][];
		//	arr[0] = new int[] { 1, 0 };

		//	new Solution().UniquePathsWithObstacles(arr);
		//}
	}
}

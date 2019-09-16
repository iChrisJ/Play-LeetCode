using System;
using System.Collections.Generic;

namespace CSharp._0733_Flood_Fill
{
	public class Solution
	{
		private bool[,] visited;
		private int[,] direction = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
		public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
		{
			if (image == null || image.Length == 0 || image[0].Length == 0 || sr < 0 || sc < 0 || newColor < 0)
				throw new Exception("Incorrect parameters.");
			visited = new bool[image.Length, image[0].Length];

			int oldColor = image[sr][sc];
			image[sr][sc] = newColor;
			DFS(image, sr, sc, oldColor, newColor);
			return image;
		}

		private void DFS(int[][] image, int x, int y, int oldColor, int newColor)
		{
			visited[x, y] = true;
			image[x][y] = newColor;
			int M = image.Length;
			int N = image[0].Length;
			for (int i = 0; i < 4; i++)
			{
				int newx = x + direction[i, 0];
				int newy = y + direction[i, 1];

				if (newx >= 0 && newx < M && newy >= 0 && newy < N && image[newx][newy] == oldColor && !visited[newx, newy])
					DFS(image, newx, newy, oldColor, newColor);
			}
		}
	}

	public class Solution2
	{
		private bool[,] visited;
		private int[,] direction = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
		public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
		{
			if (image == null || image.Length == 0 || image[0].Length == 0 || sr < 0 || sc < 0 || newColor < 0)
				throw new Exception("Incorrect parameters.");
			visited = new bool[image.Length, image[0].Length];

			int oldColor = image[sr][sc];
			BFS(image, sr, sc, oldColor, newColor);
			return image;
		}

		private void BFS(int[][] image, int x, int y, int oldColor, int newColor)
		{
			visited[x, y] = true;
			image[x][y] = newColor;
			int M = image.Length;
			int N = image[0].Length;

			Queue<(int, int)> queue = new Queue<(int, int)>();
			queue.Enqueue((x, y));

			while (queue.Count != 0)
			{
				(int, int) top = queue.Dequeue();

				for (int i = 0; i < 4; i++)
				{
					int newx = top.Item1 + direction[i, 0];
					int newy = top.Item2 + direction[i, 1];

					if (newx >= 0 && newx < M && newy >= 0 && newy < N && image[newx][newy] == oldColor && !visited[newx, newy])
					{
						visited[newx, newy] = true;
						image[newx][newy] = newColor;
						queue.Enqueue((newx, newy));
					}
				}
			}
		}
	}
}

using System.Collections.Generic;

namespace LeetCodeInCS._0841_Keys_and_Rooms
{
	public class Solution
	{
		public bool CanVisitAllRooms(IList<IList<int>> rooms)
		{
			if (rooms == null || rooms.Count == 0)
				return false;

			bool[] visited = new bool[rooms.Count];
			Queue<int> keys = new Queue<int>();
			keys.Enqueue(0);

			while (keys.Count != 0)
			{
				int key = keys.Dequeue();
				if (visited[key] == false && rooms[key] != null)
				{
					foreach (int item in rooms[key])
						keys.Enqueue(item);
					visited[key] = true;
				}
			}

			foreach (bool v in visited)
			{
				if (v == false)
					return false;
			}
			return true;
		}
	}

	public class Solution2
	{
		public bool CanVisitAllRooms(IList<IList<int>> rooms)
		{
			if (rooms == null || rooms.Count == 0)
				return false;

			bool[] visited = new bool[rooms.Count];
			visited[0] = true;

			for (int i = 0; i < rooms[0].Count; i++)
				DFS(rooms, rooms[0][i], visited);

			foreach (bool v in visited)
			{
				if (v == false)
					return false;
			}
			return true;
		}

		private void DFS(IList<IList<int>> rooms, int key, bool[] visited)
		{
			if (visited[key] == true)
				return;

			visited[key] = true;

			for (int i = 0; rooms[key] != null && i < rooms[key].Count; i++)
				DFS(rooms, rooms[key][i], visited);
		}
	}
}

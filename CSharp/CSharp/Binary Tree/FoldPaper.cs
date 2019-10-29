using System.Collections.Generic;

namespace LeetCodeInCS.Binary_Tree
{
	/// <summary>
	/// 请把一段纸条竖着放在桌子上，然后从纸条的下边向上方对折1次，压出折痕后展开。
	/// 此时折痕是凹下去的，即折痕突起的方向指向纸条的背面。如果从纸条的下边向上方连续对折2次，
	/// 压出折痕后展开，此时有三条折痕，从上到下依次是下折痕、下折痕和上折痕。
	/// 给定一个输入参数N，代表纸条都从下边向上方连续对折N次，请从上到下打印所有折痕的方向。
	///         上
	///      /      \
	///    上        下
	///  /    \    /    \
	/// 上    下  上     下
	///       ......
	/// </summary>
	class FoldPaper
	{
		public IList<char> FoldPaperResult(int n)
		{
			IList<char> res = new List<char>();
			if (n <= 0)
				return res;

			FoldPaperInOrder(1, n, true, res);
			res.Add('D');
			FoldPaperInOrder(1, n, false, res);
			return res;
		}

		private void FoldPaperInOrder(int index, int n, bool isDown, IList<char> res)
		{
			if (index == n)
				return;

			FoldPaperInOrder(index + 1, n, true, res);

			if (isDown)
				res.Add('D');
			else
				res.Add('U');

			FoldPaperInOrder(index + 1, n, false, res);
		}
	}
}

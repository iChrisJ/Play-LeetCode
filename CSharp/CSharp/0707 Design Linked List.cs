namespace LeetCodeInCS._0707_Design_Linked_List
{
	public class MyLinkedList
	{
		public class Node
		{
			public int val;
			public Node next;

			public Node(int _val, Node _next)
			{
				val = _val;
				next = _next;
			}

			public Node(int _val) : this(_val, null)
			{ }
		}

		private Node dummy;

		/** Initialize your data structure here. */
		public MyLinkedList()
		{
			dummy = new Node(0);
		}

		/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
		public int Get(int index)
		{
			Node prev = dummy;

			while (index > 0 && prev.next != null)
			{
				index--;
				prev = prev.next;
			}

			return prev.next == null ? -1 : prev.next.val;
		}

		/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
		public void AddAtHead(int val)
		{
			Node newNode = new Node(val, dummy.next);
			dummy.next = newNode;
		}

		/** Append a node of value val to the last element of the linked list. */
		public void AddAtTail(int val)
		{
			Node prev = dummy;

			while (prev.next != null)
				prev = prev.next;
			prev.next = new Node(val);
		}

		/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
		public void AddAtIndex(int index, int val)
		{
			if (index < 0)
			{
				AddAtHead(val);
				return;
			}

			Node prev = dummy;
			while (index > 0 && prev.next != null)
			{
				index--;
				prev = prev.next;
			}

			if (index == 0)
			{
				Node newNode = new Node(val, prev.next);
				prev.next = newNode;
			}
		}

		/** Delete the index-th node in the linked list, if the index is valid. */
		public void DeleteAtIndex(int index)
		{
			if (index < 0)
				return;

			Node prev = dummy;
			while (index > 0 && prev.next != null)
			{
				index--;
				prev = prev.next;
			}

			if (prev.next == null)
				return;

			if (index == 0)
			{
				Node cur = prev.next;
				prev.next = cur.next;
				cur.next = null;
			}
		}
	}
}

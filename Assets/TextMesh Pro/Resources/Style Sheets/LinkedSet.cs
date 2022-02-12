using System;
using System.Collections.Generic;


	public class LinkedSet<T> : IEnumerable<T>
	{
		private LinkedList<T> list;
		private Dictionary<T, LinkedListNode<T>> dictionary;

		public LinkedSet()
		{
			list = new LinkedList<T>();
			dictionary = new Dictionary<T, LinkedListNode<T>>();
		}

		public LinkedSet(IEqualityComparer<T> comparer)
		{
			list = new LinkedList<T>();
			dictionary = new Dictionary<T, LinkedListNode<T>>(comparer);
		}


		public bool Add(T t)
		{
			if (dictionary.ContainsKey(t))
				return false;

			LinkedListNode<T> node = list.AddLast(t);
			dictionary.Add(t, node);
			return true;
		}


		public bool Remove(T t)
		{
			LinkedListNode<T> node;

			if (dictionary.TryGetValue(t, out node))
			{
				dictionary.Remove(t);
				list.Remove(node);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Clear()
		{
			list.Clear();
			dictionary.Clear();
		}

		public bool Contains(T t)
			 => dictionary.ContainsKey(t);

		public int Count
			 => list.Count;

		public IEnumerator<T> GetEnumerator()
		 => list.GetEnumerator();

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			 => list.GetEnumerator();
	}



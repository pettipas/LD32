using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class Extensions {
	
	public static System.Random localRandom = new System.Random();
	
	public static T GetRandomElement<T>(this IEnumerable<T> list) {
		if (list.Count() == 0)
			return default(T);
		return list.ElementAt(localRandom.Next(list.Count()));
	}
}

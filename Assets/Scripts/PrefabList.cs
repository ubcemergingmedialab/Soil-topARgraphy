using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public static class PrefabList {
	/// <summary>
	/// Recycles instances of a prefab to be more performant.
	/// Given a prefab and the number of desired instances of that prefab, instances
	/// are created or destroyed from a cache so the number of gameobjects matches the
	/// number desired.
	/// </summary>
    public static void CacheInstances<T>(T prefab, Transform parent, int amountWanted, List<T> cache) where T : Object {
		if (amountWanted > cache.Count) {
			while (cache.Count < amountWanted) {
				T instance = (T) Object.Instantiate(prefab, parent);
				cache.Add(instance);
			}
		} else if (amountWanted < cache.Count) {
			while (cache.Count > amountWanted) {
				int last = cache.Count - 1;
				T instance = cache[last];
				cache.RemoveAt(last);
				Object.Destroy(instance);
			}
		}
	}
}

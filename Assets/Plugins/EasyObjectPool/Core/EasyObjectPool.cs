/* 
 * Unless otherwise licensed, this file cannot be copied or redistributed in any format without the explicit consent of the author.
 * (c) Preet Kamal Singh Minhas, http://marchingbytes.com
 * contact@marchingbytes.com
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MarchingBytes 
{
	[System.Serializable]
	public class PoolInfo {
		public string poolName;
		public string prefabPath;
		public int poolSize;
		public bool fixedSize;
	}

	class Pool 
	{
		private Stack<PoolObject> availableObjStack = new Stack<PoolObject>();

		private bool fixedSize;
		private GameObject poolObjectPrefab;
		private int poolSize;
		private string poolName;
		private int fixPoolSize;

		public Pool(Transform _parent,string poolName, string poolObjectPrefabPath, int initialCount, bool fixedSize) {
			this.poolName = poolName;
            this.poolObjectPrefab = Resources.Load<GameObject>($"Prefabs/{poolObjectPrefabPath}");
            this.poolSize = initialCount;
			this.fixPoolSize = initialCount;
			this.fixedSize = fixedSize;
			//populate the pool
			for(int index = 0; index < initialCount; index++) {
				AddObjectToPool(NewObjectInstance(_parent));
			}
		}

		//o(1)
		private void AddObjectToPool(PoolObject po) {
			//add to pool
			po.gameObject.SetActive(false);
			availableObjStack.Push(po);
			po.isPooled = true;
		}
		
		private PoolObject NewObjectInstance(Transform _parent) {
			GameObject go = (GameObject)GameObject.Instantiate(poolObjectPrefab);
			go.transform.SetParent(_parent, false);
			PoolObject po = go.GetComponent<PoolObject>();
			if(po == null) {
				po = go.AddComponent<PoolObject>();
			}
			//set name
			po.poolName = poolName;
			return po;
		}

		//o(1)
		public GameObject NextAvailableObject(Transform _parent, Vector3 position, Quaternion rotation) {
			PoolObject po = null;
			if(availableObjStack.Count > 0) {
				po = availableObjStack.Pop();
			} else if(fixedSize == false) {
				//increment size var, this is for info purpose only
				poolSize++;
				//create new object
				po = NewObjectInstance(_parent);
			} else {
				Debug.LogWarning("No object available & cannot grow pool: " + poolName);
			}
			
			GameObject result = null;
			if(po != null) {
				po.isPooled = false;
				result = po.gameObject;
				result.SetActive(true);
				
				result.transform.position = position;
				result.transform.rotation = rotation;
			}
			
			return result;
		} 
		
		//o(1)
		public void ReturnObjectToPool(PoolObject po) {
			
			if(poolName.Equals(po.poolName)) {
				
				/* we could have used availableObjStack.Contains(po) to check if this object is in pool.
				 * While that would have been more robust, it would have made this method O(n) 
				 */
				if(po.isPooled) {
					Debug.LogWarning(po.gameObject.name + " is already in pool. Why are you trying to return it again? Check usage.");	
				} else {
					AddObjectToPool(po);
					if (poolSize > fixPoolSize && availableObjStack.Count > 0)
					{
						var objStack = availableObjStack.Pop();
						GameObject.Destroy(objStack.gameObject);
						poolSize--;
					}		
				}
				
			} else {
				Debug.LogError(string.Format("Trying to add object to incorrect pool {0} {1}",po.poolName,poolName));
			}
		}
	}

	/// <summary>
	/// Easy object pool.
	/// </summary>
	public class EasyObjectPool : MonoBehaviour {

		public static EasyObjectPool instance;
		[Header("Editing Pool Info value at runtime has no effect")]
		public PoolInfo[] poolInfo;

		//mapping of pool name vs list
		private Dictionary<string, Pool> poolDictionary  = new Dictionary<string, Pool>();
		
		// Use this for initialization
		void Start () {
			//set instance
			instance = this;
			//check for duplicate names
			CheckForDuplicatePoolNames();
			//create pools
			CreatePools();
		}
		
		private void CheckForDuplicatePoolNames() {
			for (int index = 0; index < poolInfo.Length; index++) {
				string poolName = poolInfo[index].poolName;
				if(poolName.Length == 0) {
					Debug.LogError(string.Format("Pool {0} does not have a name!",index));
				}
				for (int internalIndex = index + 1; internalIndex < poolInfo.Length; internalIndex++) {
					if(poolName.Equals(poolInfo[internalIndex].poolName)) {
						Debug.LogError(string.Format("Pool {0} & {1} have the same name. Assign different names.", index, internalIndex));
					}
				}
			}
		}

		private void CreatePools() {
			foreach (PoolInfo currentPoolInfo in poolInfo) {
				
				Pool pool = new Pool(this.transform, currentPoolInfo.poolName, currentPoolInfo.prefabPath, 
				                     currentPoolInfo.poolSize, currentPoolInfo.fixedSize);

				//Debug.Log("Creating pool: " + currentPoolInfo.poolName);
				//add to mapping dict
				poolDictionary[currentPoolInfo.poolName] = pool;
			}
		}


		/* Returns an available object from the pool 
		OR 
		null in case the pool does not have any object available & can grow size is false.
		*/
		public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation) {
			GameObject result = null;
			
			if(poolDictionary.ContainsKey(poolName)) {
				Pool pool = poolDictionary[poolName];
				result = pool.NextAvailableObject(this.transform,position,rotation);
				//scenario when no available object is found in pool
				if(result == null) {
					Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
				}
				
			} else {
				Debug.LogError("Invalid pool name specified: " + poolName);
			}
			
			return result;
		}

		public void ReturnObjectToPool(GameObject go) {
			PoolObject po = go.GetComponent<PoolObject>();
			if(po == null) {
				Debug.LogWarning("Specified object is not a pooled instance: " + go.name);
			} else {
				if(poolDictionary.ContainsKey(po.poolName)) {
					Pool pool = poolDictionary[po.poolName];
					pool.ReturnObjectToPool(po);
				} else {
					Debug.LogWarning("No pool available with name: " + po.poolName);
				}
			}
		}

		public bool GetObjectPoolReturn(string _itemName) => poolDictionary.ContainsKey(_itemName);
	}
}

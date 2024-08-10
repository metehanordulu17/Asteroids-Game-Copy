using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorePoint;
    public static ObjectPooler instance;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public List<Pool> pools;
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    private void Awake()
    {
        instance = this;
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size;i++)
            {
                GameObject obj =Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag,objectPool);

        }
    }
    public GameObject SpawnObjectFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn=PoolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        PoolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public void UpdateScore(int scoreWorth)
    {
        scorePoint.text = (int.Parse(scorePoint.text) + scoreWorth).ToString();
    }
}

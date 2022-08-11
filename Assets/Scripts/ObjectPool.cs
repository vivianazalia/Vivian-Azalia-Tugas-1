using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //public static ObjectPool Instance = null;
    //
    //private void Awake()
    //{
    //    if(Instance == null)
    //    {
    //        Instance = this;
    //    }
    //}

    [System.Serializable]
    public struct SpawnRange
    {
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
    }

    public GameObject prefab;
    public List<GameObject> pools;

    [SerializeField] private int amountPool;

    [SerializeField] private SpawnRange spawnPos;

    [SerializeField] private float spawnTimer;
    private float currentTimeSpawn;

    private void Start()
    {
        pools = new List<GameObject>();
        for(int i = 0; i < amountPool; i++)
        {
            GameObject tmp = Instantiate(prefab, SpawnPos(), Quaternion.identity);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
            pools.Add(tmp);
        }
    }

    private void Update()
    {
        SpawnObject();
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (!pools[i].activeInHierarchy)
            {
                pools[i].SetActive(true);
                return pools[i];
            }
        }

        return null;
    }

    public void AddToPool(GameObject obj)
    {
        if (obj.activeInHierarchy)
        {
            obj.SetActive(false);
            obj.transform.position = SpawnPos();
        }
    }

    public void AddAllObjectToPool()
    {
        foreach (GameObject obj in pools)
        {
            if (obj.activeInHierarchy)
            {
                AddToPool(obj);
            }
        }
    }

    public Vector2 SpawnPos()
    {
        Vector2 pos = new Vector2((Random.Range(spawnPos.minX, spawnPos.maxX)), (Random.Range(spawnPos.minY, spawnPos.maxY)));
        return pos;
    }

    private void SpawnObject()
    {
        if (!GameManager.instance.IsGameOver)
        {
            currentTimeSpawn += Time.deltaTime;
            if(currentTimeSpawn > spawnTimer)
            {
                GameObject obj = GetObject();
                if (obj == null) return;
                currentTimeSpawn = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public List<GameObject> prefabs;
    public List<GameObject> humans;
    public List<GameObject> zombies;

    [SerializeField] private int amountPoolHuman;
    [SerializeField] private int amountPoolZombie;

    [SerializeField] private SpawnObject spawnPosHuman;
    [SerializeField] private SpawnObject spawnPosZombie;

    private void Start()
    {
        humans = new List<GameObject>();
        for(int i = 0; i < amountPoolHuman; i++)
        {
            GameObject tmp = Instantiate(prefabs[0], spawnPosHuman.SpawnPos(), Quaternion.identity);
            tmp.SetActive(false);
            humans.Add(tmp);
        }

        zombies = new List<GameObject>();
        for (int i = 0; i < amountPoolHuman; i++)
        {
            GameObject tmp = Instantiate(prefabs[1], spawnPosZombie.SpawnPos(), Quaternion.identity);
            tmp.SetActive(false);
            zombies.Add(tmp);
        }
    }

    public GameObject GetObject(int index)
    {
        if(index == 0)
        {
            for(int i = 0; i < humans.Count; i++)
            {
                if (!humans[i].activeInHierarchy)
                {
                    return humans[i];
                }
            }
        } 
        else if(index == 1)
        {
            for (int i = 0; i < zombies.Count; i++)
            {
                if (!zombies[i].activeInHierarchy)
                {
                    return zombies[i];
                }
            }
        }

        return null;
    }

    public void AddToPool(GameObject obj)
    {
        if (obj.activeInHierarchy)
        {
            obj.SetActive(false);
            if (obj.CompareTag("Enemy"))
            {
                obj.transform.position = spawnPosZombie.SpawnPos();
            }

            if (obj.CompareTag("Player"))
            {
                obj.transform.position = spawnPosHuman.SpawnPos();
            }
        }
    }

    public void AddAllObjectToPool()
    {
        foreach (GameObject obj in ObjectPool.Instance.humans)
        {
            if (obj.activeInHierarchy)
            {
                ObjectPool.Instance.AddToPool(obj);
            }
        }

        foreach (GameObject obj in ObjectPool.Instance.zombies)
        {
            if (obj.activeInHierarchy)
            {
                ObjectPool.Instance.AddToPool(obj);
            }
        }
    }
}

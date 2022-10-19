using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;

    public GameObject bulletPrefab;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bulletPrefab = (GameObject)Resources.Load("Bullet");
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject go = Instantiate(bulletPrefab);
            go.SetActive(false);
            pooledObjects.Add(go);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {

                return pooledObjects[i];
            }
        }
        return null;
    }

}

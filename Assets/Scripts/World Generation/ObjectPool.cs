using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Pooled Objects:")]
    [SerializeField]
    public List<GameObject> poolList;
    [Tooltip("The size of this object pool.")]
    [SerializeField]
    int poolSize = 5;
    [SerializeField]
    public GameObject pooledObject;
    void Start()
    {
        FillPool();
    }

    public GameObject GetPooledObject()
    {
        if (poolList.Count == 0)
        {
            FillPool();
        }
        GameObject go = poolList[poolList.Count - 1];

        poolList.Remove(go);

        go.transform.parent = null;
        go.SetActive(true);

        return go;
    }
    public void ReturnPooledObject(GameObject go)
    {
        poolList.Add(go);
        go.SetActive(false);
        go.transform.parent = transform;
    }
    void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(pooledObject);
            poolList.Add(go);
            go.transform.parent = transform;
            go.SetActive(false);
        }
    }
    void Update()
    {
        
    }
}

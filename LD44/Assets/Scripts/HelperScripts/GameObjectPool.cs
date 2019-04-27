using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int nmbrToPrespawn;
    private Queue<GameObject> pool;

    void Awake()
    {
        pool = new Queue<GameObject>();
        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < nmbrToPrespawn; i++)
        {
            GameObject obj = Instantiate<GameObject>(objectToPool, this.transform);
            obj.SetActive(false);
            SendToPool stp = obj.GetComponent<SendToPool>();
            if (stp)
            {
                stp.pool = this;
            }
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if(pool.Count <= 0)
        {
            FillPool();
        }
        return pool.Dequeue();
    }

    public void Return(GameObject obj)
    {
        obj.transform.parent = this.transform;
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}

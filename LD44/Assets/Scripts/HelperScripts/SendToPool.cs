using UnityEngine;
using System.Collections;

public class SendToPool : MonoBehaviour
{
    [HideInInspector]
    public GameObjectPool pool;
    public void SendBackToPool(GameObject obj)
    {
        pool.Return(obj);
    }
}

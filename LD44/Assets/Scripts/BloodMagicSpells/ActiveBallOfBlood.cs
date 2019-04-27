using UnityEngine;
using System.Collections;

public class ActiveBallOfBlood : MonoBehaviour, ActiveBloodMagic
{
    [SerializeField] private float bloodCost;
    [SerializeField] private GameObjectPool pool;

    void ActiveBloodMagic.CastMagic()
    {
        GameObject ball = pool.Get();
        ball.GetComponent<BallOfBloodController>().fireDirection = this.transform.right;
        ball.transform.position = this.transform.position + this.transform.right;
        ball.SetActive(true);
    }

    float ActiveBloodMagic.GetBloodCost()
    {
        return bloodCost;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private ObstacleCon obstacleCon;
    [SerializeField]
    private int maxCount = 20;
    Queue<ObstacleCon> obstacleConQueue;
    private Vector3 setPos = new Vector3(100, 100, 0);

    private void Awake()
    {
        obstacleConQueue = new Queue<ObstacleCon>();
       
        for (int i = 0; i < maxCount; i++)
        {
            ObstacleCon tmpObstacle = Instantiate(obstacleCon, setPos, Quaternion.identity, transform);
            obstacleConQueue.Enqueue(tmpObstacle);
        }
    }

    public ObstacleCon Launcher(Vector3 _pos)
    {
        if (obstacleConQueue.Count == 0) return null;
        ObstacleCon obstacle = obstacleConQueue.Dequeue();
        obstacle.gameObject.SetActive(true);
        //Debug.Log("_pos.y:" + _pos.y);
        obstacle.ShowInStage(_pos);
        return obstacle;
    }

    public void Collect(ObstacleCon _obstacle)
    {
        _obstacle.gameObject.SetActive(false);
        obstacleConQueue.Enqueue(_obstacle);
    }
}

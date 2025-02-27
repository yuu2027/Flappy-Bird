using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private ObstacleCon obstacleCon;
    [SerializeField]
    private ObjectPoolManager objectPool;
    [SerializeField]
    private Timer timer;
    public float interval;
    public int obstacleCount = 0;
    int index = 0;
    

    private void Start()
    {
        StartCoroutine(GenerateObstacle());
    }

    IEnumerator GenerateObstacle()
    {
        while (true)
        {
            int random = Random.Range(0, 2);
            //Debug.Log("timer:" + timer.gametimer);
            if (random == 0)
            {
                obstacleCount = 1;
                //Debug.Log("èoåª");
                objectPool.Launcher(SetObstaclePosition_One());
                //objectPool.Launcher(new Vector3(11, 0, 0));
            }
            else
            {
                obstacleCount = 2;
                //Debug.Log("èoåª");
                while (true)
                {
                    var toPosition = SetObstaclePosition_Two_To();
                    var unPosition = SetObstaclePosition_Two_Un();
                    if (DistanceMeasur(toPosition, unPosition))
                    {
                        objectPool.Launcher(unPosition);
                        objectPool.Launcher(toPosition);
                        break;
                    }
                    yield return null;
                }
            }
            yield return new WaitForSeconds(interval);
        }
    }

    IEnumerator SetSpawnInterval()
    {
        yield return new WaitForSeconds(4);
    }

    private Vector3 SetObstaclePosition_One()
    {
        float rndY_Un = Random.Range(-3, -1.9f);
        float rndY_To = Random.Range(1, 2.1f);
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            obstacleCon.centerPos = new Vector3(11, rndY_Un);
            //Debug.Log("â∫");
            return new Vector3(11, rndY_Un); 
        }
        else if (random == 1)
        {
            obstacleCon.centerPos = new Vector3(11, rndY_To);
            //Debug.Log("è„");
            return new Vector3(11, rndY_To);
        }
        return Vector3.zero;
    }

    Vector3 SetObstaclePosition_Two_Un()
    {
        float rndY_Un = Random.Range(-7f, -4f);
        return new Vector3(11, rndY_Un);
    }

    Vector3 SetObstaclePosition_Two_To()
    {
        float rndY_To = Random.Range(5f, 8f);
        return new Vector3(11, rndY_To);
    }

    bool DistanceMeasur(Vector3 toPos, Vector3 unPos)
    {
        var distance = toPos.y - unPos.y;
        if (12 <= distance && distance <= 13)
        {
            return true;
        }
        return false;
    }
}

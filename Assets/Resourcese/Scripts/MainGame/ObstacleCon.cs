using Mono.Cecil;
using System.Collections;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;

public class ObstacleCon : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    ObjectPoolManager objectPool;
    Timer timer;
    ObstacleManager obstacleManager;
    public float amplitude = 0.5f;
    public float frequency = 1.0f;
    private Vector3 startPosition;
    public Vector3 centerPos;
    public int signal = 0;
    int count = 0;
    void Start()
    {
        objectPool = Object.FindFirstObjectByType<ObjectPoolManager>(); // シーンから自動的に取得
        timer = Object.FindFirstObjectByType<Timer>();
        obstacleManager = Object.FindFirstObjectByType<ObstacleManager>();
        gameObject.SetActive(false);
        startPosition = transform.position;
        //Debug.Log("centorPos: " + centerPos.y);
    }

    void Update()
    {
        if (count == 0)
        {
            //Debug.Log("signal:" + signal);
            if(timer.gametimer < 20){ signal = 0; }
            else { signal = 1; }
            count = 1;
        }
        if (signal == 0 || obstacleManager.obstacleCount == 2)
        {
            float x = Time.deltaTime * moveSpeed;
            transform.Translate(-x, 0, 0);
            
        }
        else if (signal == 1 && obstacleManager.obstacleCount == 1)
        {
            float y = 0;
            y = 0.01f * Mathf.Sin(Time.time * frequency * 5);
            float x = Time.deltaTime * moveSpeed;
            transform.Translate(-x, y, 0);
        }
        if (transform.position.x < -10)
        {
            HideFromStage();
        }
    }

    IEnumerator MoveHorizontal()
    {
        while (true)
        {
            float x = Time.deltaTime * moveSpeed;
            transform.Translate(-x, 0, 0);
            if (transform.position.x < -10)
            {
                HideFromStage();
            }
            yield return null;
        }
    }

    IEnumerator MoveVertical()
    {
        float y = 0;
        y = 0.01f * Mathf.Sin(Time.time * frequency * 5);
        float x = Time.deltaTime * moveSpeed;
        transform.Translate(-x, y, 0);
        if (transform.position.x < -10)
        {
            HideFromStage();
        }
        yield return null;
    }

    public void ShowInStage(Vector3 _pos)
    {
        //Debug.Log("出現位置:" + _pos.y);
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        objectPool.Collect(this);
    }
}

using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    [System.NonSerialized]
    public float gametimer;
    [SerializeField]
    private GameManager gameManager;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        gametimer = 0;
    }

    void Update()
    {
        if (gameManager.isGame)
        {
        gametimer += Time.deltaTime;
        timerText.text = gametimer.ToString("f2");            
        }
    }
}

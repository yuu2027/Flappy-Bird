using SelectCharacter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGame = false;
    [SerializeField]
    private MyGameManagerData myGameManagerData = null;
    void Start()
    {
        isGame = true;
    }
    public MyGameManagerData GetMyGameManagerData()
    {
        return myGameManagerData;
    }
}

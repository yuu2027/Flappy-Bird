using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SelectCharacter;
using TMPro;
using System.Collections;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button charButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject charaSelect;
    [SerializeField]
    private MyGameManagerData myGameManagerData = null;
    [SerializeField]
    private GameObject textObject;


    void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        charButton.onClick.AddListener(OnClickCharButton);
        backButton.onClick.AddListener(OnClickBackButton);
    }

    void OnClickStartButton()
    {
        if (myGameManagerData.character != null)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            StartCoroutine(ViewText());
        }
    }

    void OnClickCharButton()
    {
        charaSelect.gameObject.SetActive(true);
    }

    void OnClickBackButton()
    {
        charaSelect.gameObject.SetActive(false);
    }

    public MyGameManagerData GetMyGameManagerData()
    {
        return myGameManagerData;
    }

    IEnumerator ViewText()
    {
        textObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        textObject.SetActive(false);
    }
}

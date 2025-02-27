using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttonanager : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button titleButton;

    void Start()
    {
        retryButton.onClick.AddListener(OnClickRetryButton);
        titleButton.onClick.AddListener(OnClickTitleButton);
    }

    void OnClickRetryButton()
    {
        SceneManager.LoadScene("Main");
    }

    void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}

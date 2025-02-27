using SelectCharacter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject displayChara;
    [SerializeField]
    private GameObject charaSelect;
    private MyGameManagerData myGameManagerData;
    private static bool hasExecuted = false;
    private void Start()
    {
        myGameManagerData = FindFirstObjectByType<TitleManager>().GetMyGameManagerData();
        if(!hasExecuted)
        {
            displayChara.SetActive(false);
            hasExecuted = true;
        }
        else
        {
            SpriteRenderer displayCharaSprite = displayChara.GetComponent<SpriteRenderer>();
            SpriteRenderer charaSprite = myGameManagerData.character.GetComponent<SpriteRenderer>();
            displayCharaSprite.sprite = charaSprite.sprite;
        }
    }

    public void OnSelectCharacter(GameObject character)
    {
        myGameManagerData.SetCharacter(character);
        displayChara.SetActive(true);
        SpriteRenderer displayCharaSprite = displayChara.GetComponent<SpriteRenderer>();
        SpriteRenderer charaSprite = character.GetComponent<SpriteRenderer>();
        displayCharaSprite.sprite = charaSprite.sprite;
        charaSelect.gameObject.SetActive(false);
    }


}


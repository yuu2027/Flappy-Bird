using SelectCharacter;
using System.Collections;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    public float jumpPower;
    Rigidbody2D rb;
    private bool goJump;
    [SerializeField]
    private CameraManager cameraManager;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject resultCanvas;
    [SerializeField]
    private Ranking ranking;
    private bool canAction = false;
    private MyGameManagerData gameManagerData;

    private void Awake()
    {
        gameManagerData = FindFirstObjectByType<GameManager>().GetMyGameManagerData();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameObject = gameManagerData.GetCharacter();
        SpriteRenderer sourceSprite = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sourceSprite.sprite;
    }

    IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();
        resultCanvas.SetActive(false);
        rb.AddForce(Vector3.right * 5f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        canAction = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAction)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (goJump && gameManager.isGame)
        {
            var jumpNow = new Vector2(0, jumpPower);
            rb.AddForce(jumpNow, ForceMode2D.Impulse);
            goJump = false;
        }
    }

    public void Jump()
    {
        goJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadWall")
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return StartCoroutine(cameraManager.Shake());
        gameManager.isGame = false;
        ranking.SetRank();
        resultCanvas.SetActive(true);
        Destroy(gameObject);
    }
}

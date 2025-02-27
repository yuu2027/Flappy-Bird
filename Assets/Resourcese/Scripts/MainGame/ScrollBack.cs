using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    [SerializeField]
    private Player_Move p_Move;
    [SerializeField]
    private int sign;
    [SerializeField]
    private ObstacleCon obstacleCon;

    private void FixedUpdate()
    {
        var move = new Vector3(obstacleCon.moveSpeed, 0, 0);
        transform.Translate(sign * move * Time.deltaTime * 1.1f);
        if (transform.position.x <= -18.56f)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = 18f;
            transform.position = newPosition;
        }
    }
}

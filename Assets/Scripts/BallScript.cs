using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private int ballSpeed = 10;
    private Rigidbody2D ballRigidbody2D;
    private GameObject playerWhoLastHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        ballRigidbody2D.linearVelocity = new Vector2(ballSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            playerWhoLastHit = collision2D.gameObject;
        }
    }
}

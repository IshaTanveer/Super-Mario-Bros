using UnityEngine;

public class GoombaCollision : MonoBehaviour
{
    private float direction = -1.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject TargetObject;
    [SerializeField] GameObject GameOverPanel;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Blocks")
        {
            direction = direction * -1.0f;
        }
        else if (other.gameObject.tag == "Player")
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game over");
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "GroundCheck")
        {
            Debug.Log("Goomba Dead");
        }
    }*/
    private void Update()
    {
        spawnGoombas();
    }
    public void spawnGoombas()
    {
        if (TargetObject.transform.position.x + 15.0f > rb.transform.position.x)
        {
            rb.linearVelocity = new Vector2(1.5f * direction, rb.linearVelocity.y);
        }
    }
}

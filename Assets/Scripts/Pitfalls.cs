using UnityEngine;

public class Pitfalls : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    private void Start() {
        GameOverPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pit")
        {
            GameOverPanel.SetActive(true);
            Debug.Log("You are Dead!");
        }
    }

}

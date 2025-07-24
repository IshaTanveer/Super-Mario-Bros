using UnityEngine;

public class Pitfalls : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] GameObject GameOverPanel;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        GameOverPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pit")
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("You are Dead!!!!!!!!!!!!!!!!!!!!!!!!");
            audioManager.playSFX(audioManager.gameOver);
        }
    }

}

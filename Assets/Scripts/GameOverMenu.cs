using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    Collectibles collectibles;
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI finalCoins;
    void Start()
    {
        collectibles = FindFirstObjectByType<Collectibles>();
    }
    void Update()
    {
        finalScore.text = "Scores \n" + collectibles.getScores();
        finalCoins.text = "Coins \n" + collectibles.getCoins();
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}

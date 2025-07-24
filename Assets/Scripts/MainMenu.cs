using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip introduction;
    private void Awake() {
        audioSource.clip = introduction;
        audioSource.Play();
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

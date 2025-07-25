using UnityEngine;
using UnityEngine.Tilemaps;

public class Blocks : MonoBehaviour
{
    //[SerializeField] TileBase tileToPlace; // tile to replace
    AudioManager audioManager;
    PlayerDetection playerDetection;
    private Tilemap coinTilemap;
    private void Awake()
    {
        if (coinTilemap == null)
            coinTilemap = GetComponent<Tilemap>();
    }
    private void Start()
    {
        playerDetection = FindFirstObjectByType<PlayerDetection>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            if (playerDetection.detectPlayerFromBlocks(other, coinTilemap))
            {
                audioManager.playSFX(audioManager.thud);
                Debug.Log("Tile detected");
            }
        }
    }
}

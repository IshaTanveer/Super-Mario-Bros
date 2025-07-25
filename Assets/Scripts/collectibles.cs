using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectibles : MonoBehaviour
{
    [SerializeField] TMP_Text Coin;
    [SerializeField] TMP_Text Score;
    [SerializeField] GameObject tileToPlace;
    [SerializeField] GameObject coinToPlace;  // tile to replace
    private float coins = 0;
    private float score = 0;
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
    public float getCoins()
    {
        return coins;
    }
    public float getScores()
    {
        return score;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            if (playerDetection.detectPlayerFromCollectible(other, tileToPlace, coinToPlace, coinTilemap))
            {
                audioManager.playSFX(audioManager.coin);
                Debug.Log("Coin collected!");
                coins = coins + 1;
                score = score + 200;
                Coin.text = "Coins \n" + coins.ToString();
                Score.text = "Scores \n" + score.ToString();
            }
        }
    }
}

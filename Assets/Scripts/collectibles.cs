using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectibles : MonoBehaviour
{
    private Tilemap coinTilemap;
    [SerializeField] TMP_Text Coin;
    [SerializeField] TMP_Text Score;
    [SerializeField] TileBase tileToPlace; // tile to replace
    private HashSet<Vector3Int> collectedTiles = new HashSet<Vector3Int>();
    private float coins = 0;
    private float score = 0;
    private void Awake()
    {
        if (coinTilemap == null)
            coinTilemap = GetComponent<Tilemap>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerHead")
        {
            Vector3 playerPosition = other.transform.position;
            Vector3Int playerCell = coinTilemap.WorldToCell(playerPosition);
            Vector3Int tileAbove = new Vector3Int(playerCell.x, playerCell.y + 1, playerCell.z);

            if (collectedTiles.Contains(tileAbove))
            {
                Debug.Log("Coin already collected!");
            }
            else
            {
                TileBase tile = coinTilemap.GetTile(tileAbove);
                if (tile != null)
                {
                    Debug.Log("Coin collected!");
                    coinTilemap.SetTile(tileAbove, tileToPlace);
                    collectedTiles.Add(tileAbove);
                    coins = coins + 1;
                    score = score + 200;
                    Coin.text = "Coin \n" + coins.ToString();
                    Score.text = "Score \n" + score.ToString();
                }
                else
                {
                    Debug.Log("No Tile");
                }
            }
        }
    }
    public float getCoins()
    {
        return coins;
    }
    public float getScores()
    {
        return score;
    }
}

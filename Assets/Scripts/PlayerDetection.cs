using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] float duration;

    public bool detectPlayerFromCollectible(Collider2D other, GameObject tileToPlace, GameObject coinToPlace, Tilemap tilemap)
    {
        Vector3 playerPosition = other.transform.position;
        Vector3Int playerCell = tilemap.WorldToCell(playerPosition);
        Vector3Int tileAbove = new Vector3Int(playerCell.x, playerCell.y + 1, playerCell.z);
        TileBase tile = tilemap.GetTile(tileAbove);
        if (tile != null)
        {
            Vector3 worldPos = tilemap.CellToWorld(tileAbove) + tilemap.cellSize / 2f;
            tilemap.SetTile(tileAbove, null);
            //Instantiate(tileToPlace, worldPos, Quaternion.identity);
            GameObject placedObject = Instantiate(tileToPlace, worldPos, Quaternion.identity);
            Rigidbody2D rb = placedObject.GetComponent<Rigidbody2D>();
            GameObject placedCoin = Instantiate(coinToPlace, worldPos, Quaternion.identity);
            Rigidbody2D rbCoin = placedCoin.GetComponent<Rigidbody2D>();

            Bounce(rb, 0.2f, 3.0f);
            Bounce(rbCoin, 3.0f, 2.0f);
            return true;
        }
        else
        {
            Debug.Log("No Tile");
            return false;
        }
    }

    private void Bounce(Rigidbody2D rb, float height, float denomenator)
    {
        if (rb != null)
            {
                rb.DOMove(new Vector3(rb.transform.position.x, rb.transform.position.y + height,
                rb.transform.position.z), duration / denomenator)
                .SetEase(Ease.OutQuad)
                .SetLoops(2, LoopType.Yoyo);
            }
    }

    public bool detectPlayerFromBlocks(Collider2D other, Tilemap tilemap)
    {
        Vector3 playerPosition = other.transform.position;
        Vector3Int playerCell = tilemap.WorldToCell(playerPosition);
        Vector3Int tileAbove = new Vector3Int(playerCell.x, playerCell.y + 1, playerCell.z);
        TileBase tile = tilemap.GetTile(tileAbove);
        if (tile != null)
        {
            Debug.Log("Block Tile");
            return true;
        }
        else
        {
            Debug.Log("No Tile");
            return false;
        }
    }



    /*public bool detectPlayer(Collider2D other, TileBase tileToPlace, Tilemap tilemap)
    {
        Vector3 playerPosition = other.transform.position;
        Vector3Int playerCell = tilemap.WorldToCell(playerPosition);
        Vector3Int tileAbove = new Vector3Int(playerCell.x, playerCell.y + 1, playerCell.z);

        if (collectedTiles.Contains(tileAbove))
        {
            Debug.Log("Coin already collected!");
            return false;
        }
        else
        {
            TileBase tile = tilemap.GetTile(tileAbove);
            if (tile != null)
            {
                tilemap.SetTile(tileAbove, tileToPlace);

                collectedTiles.Add(tileAbove);
                return true;
            }
            else
            {
                Debug.Log("No Tile");
                return false;
            }
        }
    }*/
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDetection : MonoBehaviour
{
    private HashSet<Vector3Int> collectedTiles = new HashSet<Vector3Int>();
    public bool detectPlayer(Collider2D other, TileBase tileToPlace, Tilemap tilemap)
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
    }
}

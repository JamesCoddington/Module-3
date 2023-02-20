using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum Type
    {
        Invalid,
        Empty,
        Mine,
        Number,
    }

    public Vector3 position;
    public Type type;
    public int number;
    public bool revealed;
    public bool flagged;
    public bool exploded;

    public Vector3 rightTilePosition;
    public Vector3 downTilePosition;
    public Vector3 bottomRightTilePosition;
    public Vector3 topRightTilePosition;

    public List<Tile> nearbyTiles;

    public Tile rightTile;
    public Tile leftTile;
    public Tile upTile;
    public Tile downTile;

    public Tile topLeftTile;
    public Tile topRightTile;
    public Tile bottomLeftTile;
    public Tile bottomRightTile;

    private void Start()
    {
        type = Type.Empty;
        position = transform.position;
        rightTilePosition = position - new Vector3(0f, 0f, 1.5f);
        downTilePosition = position - new Vector3(1.5f, 0f, 0f);
        topRightTilePosition = position + new Vector3(1.5f, 0f, -1.5f);
        bottomRightTilePosition = position - new Vector3(1.5f, 0f, 1.5f);
    }

    public void CheckSides(Tile[] tiles)
    {
        foreach (var tile in tiles)
        {
            print(tile.position == rightTilePosition);
            if (tile.position == rightTilePosition)
            {
                // rightTile = tile;
                // tile.leftTile = this;
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == downTilePosition)
            {
                // downTile = tile;
                // tile.upTile = this;
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == topRightTilePosition)
            {
                // topRightTile = tile;
                // tile.bottomLeftTile = this;
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == bottomRightTilePosition)
            {
                // bottomRightTile = tile;
                // tile.topLeftTile = this;
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            }
        }
    }
}

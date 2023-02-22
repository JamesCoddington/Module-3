using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public Vector3Int position;

    private void Start()
    {
        Invoke("SetTiles", 2);
    }

    private void SetTiles()
    {
        Tile[] tiles = GetComponentsInChildren<Tile>();
        foreach (var tile in tiles)
        {
            tile.CheckSides(tiles);
        }
        SetMines();
    }

    private void SetMines()
    {
        var bombPlaces = new List<int>();
        Tile[] tiles = GetComponentsInChildren<Tile>();
        for (int i = 0; i < 20; i++)
        {
            var place = Random.Range(0, tiles.Length);
            while (bombPlaces.Contains(place))
            {
                place = Random.Range(0, tiles.Length);
            }
            tiles[place].type = Tile.Type.Mine;
            bombPlaces.Add(place);
        }
        print("Bombs Done");
        SetNumbers();
    }

    private void SetNumbers()
    {
        Tile[] tiles = GetComponentsInChildren<Tile>();
        foreach (var tile in tiles)
        {
            if (tile.type != Tile.Type.Mine)
            {
                tile.SetBombCount();
            }
        }
    }
}
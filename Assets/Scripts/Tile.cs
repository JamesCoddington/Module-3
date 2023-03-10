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

    public GameObject bombText;
    public GameObject space;
    public GameObject flag;
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

    private bool isChecked;

    private void Start()
    {
        isChecked = false;
        type = Type.Empty;
        flagged = false;
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
            if (tile.position == rightTilePosition)
            {
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == downTilePosition)
            {
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == topRightTilePosition)
            {
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            } else if (tile.position == bottomRightTilePosition)
            {
                nearbyTiles.Add(tile);
                tile.nearbyTiles.Add(this);
            }
        }
    }

    public void SetBombCount()
    {
        foreach (var tile in nearbyTiles)
        {
            if (tile.type == Type.Mine)
            {
                type = Type.Number;
                number += 1;
            }
        }

        if (type == Type.Number)
        {
            bombText.GetComponent<TextMesh>().text = number.ToString();
        } else if (type == Type.Mine)
        {
            bombText.GetComponent<TextMesh>().text = "B";
        }
    }

    public void OnClick()
    {
        if (!flagged)
        {
            space.SetActive(false);
            isChecked = true;
            switch (type)
            {
                case Type.Empty:
                    foreach (var tile in nearbyTiles)
                    {
                        if (tile.type == Type.Empty && !tile.isChecked)
                        {
                            tile.OnClick();
                        }
                    }
                    break;
                case Type.Number:
                    bombText.SetActive(true);
                    break;
                case Type.Mine:
                    bombText.SetActive(true);
                    // BlowUp();
                    break;
            }
        }
    }

    public void Flag()
    {
        flagged = !flagged;
        flag.SetActive(flagged);
    }

    public void BlowUp()
    {
        foreach (var tile in nearbyTiles)
        {
            if (tile.type == Type.Mine && tile.isChecked == false)
            {
                tile.space.SetActive(false);
                tile.bombText.SetActive(true);
            }
            tile.isChecked = true;

        }
    }
}

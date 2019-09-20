using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapTile : Tile
{

    [SerializeField] public Material selectedMaterial;
    SpriteRenderer renderer;

    public void highliteTile()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.material = selectedMaterial;
    }

}

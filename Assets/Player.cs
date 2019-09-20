using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2D;
    BoxCollider2D collider;
    public Grid grid;
    public Material highliteMaterial;
    private Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    bool AttemptMove(Vector2 direction)
    {
        collider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        collider.enabled = true;

        if (hit.collider == null || Vector3.Distance(transform.position, hit.collider.transform.position) > 1)
        {
            return true;
        }

        return false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (AttemptMove(Vector2.up))
            {
                rb2D.transform.Translate(Vector2.up);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (AttemptMove(Vector2.down))
            {
                rb2D.transform.Translate(Vector2.down);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (AttemptMove(Vector2.left))
            {
                rb2D.transform.Translate(Vector2.left);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (AttemptMove(Vector2.right))
            {
                rb2D.transform.Translate(Vector2.right);
            }
        }
    }

    private void OnMouseDown()
    {

        //Debug.Log(gameObject.transform.position);

        var layers = grid.GetComponentsInChildren<Tilemap>();

        foreach (Tilemap tilemap in layers) {
            if (tilemap.name == "Paths")
            {
                map = tilemap;
            }
        }

        var currentCell = grid.WorldToCell(transform.position);

        var tile = map.GetInstantiatedObject(currentCell);
        Debug.Log("tile? " + tile.gameObject);


        //sprRenderer.material = highliteMaterial;


        //Vector3Int targetCell = new Vector3Int(currentCell.x, currentCell.y + 1, currentCell.z);

        //Debug.Log("target Cell" + targetCell);

        //var targetTile = map.GetTile(targetCell) as MapTile;
        //Debug.Log("targettile " + targetTile);
        //targetTile.highliteTile();

        ////var tileInstance = targetTile.GetInstanceID();   //.gameObject.GetComponent<SpriteRenderer>(); <-- NOPE
        
        ////Debug.Log("renderer " + spriteRenderer);

        ////spriteRenderer.material = highliteMaterial;

    }
}

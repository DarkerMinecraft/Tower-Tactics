using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacer : MonoBehaviour
{

    public GameObject tower;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile[] disallowTiles;

    [SerializeField]
    private EnemySpawner enemySpawner;

    private SpriteRenderer radiusCircle;

    private Color gray, red;

    private GameObject towerObject;

    private void Start()
    {
        gray = new Color(0.5f, 0.5f, 0.5f, 0.4f);
        red = new Color(1, 0, 0, 0.4f);
        CreateTower();
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        towerObject.transform.position = mousePos;

        if (CanPlace(mousePos))
        {
            radiusCircle.color = gray;

            if (Input.GetMouseButtonDown(0))
            {
                towerObject.GetComponent<TowerController>().spawner = enemySpawner;
                CreateTower();
            }
        }
        else radiusCircle.color = red;

        
    }

    bool CanPlace(Vector2 position)
    {
        Tile tile = (Tile) tilemap.GetTile(ConvertPosition(position));

        Debug.Log(tile);

        for (int i = 0; i < disallowTiles.Length; i++) 
        {
            if (tile == disallowTiles[i])
                return false;
        }
        return true;
    }

    Vector3Int ConvertPosition(Vector2 position)
    {
        return tilemap.WorldToCell(position);
    }

    void CreateTower()
    {
        towerObject = Instantiate(tower, transform);
        radiusCircle = towerObject.GetComponentsInChildren<SpriteRenderer>()[0];

        float radius = towerObject.GetComponent<TowerController>().GetRadius();
        radiusCircle.transform.localScale = new Vector3(radius, radius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacer : MonoBehaviour
{

    [SerializeField]
    private float towerDistance = 0.3f;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile[] disallowTiles;

    [SerializeField]
    private EnemySpawner enemySpawner;

    private int cost; 

    private SpriteRenderer radiusCircle;

    private Color gray, red;

    private GameObject towerObject;

    private bool towerBought;

    private void Start()
    {
        gray = new Color(0.5f, 0.5f, 0.5f, 0.4f);
        red = new Color(1, 0, 0, 0.4f);

        towerBought = false;
    }

    void Update()
    {
        if (!towerBought) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        towerObject.transform.position = mousePos;

        if (CanPlace(mousePos))
        {
            radiusCircle.color = gray;

            if (Input.GetMouseButtonDown(0))
            {
                towerObject.GetComponent<TowerController>().spawner = enemySpawner;
                CoinsChanger.ChangeCoins(-cost);
                towerBought = false;
                towerObject.GetComponent<TowerController>().radiusCircle.enabled = false;
            }
        }
        else radiusCircle.color = red;

        if(Input.GetMouseButtonDown(1))
        {
            Destroy(towerObject);
            towerBought = false;
        }
    }

    bool CanPlace(Vector2 position)
    {
        Tile tile = (Tile) tilemap.GetTile(ConvertPosition(position));

        for (int i = 0; i < disallowTiles.Length; i++) 
        {
            if (tile == disallowTiles[i])
                return false;
        }

        if (transform.childCount != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject != towerObject)
                {
                    Vector2 childPos = transform.GetChild(i).position;

                    float distance = Vector2.Distance(childPos, position);

                    if (distance < towerDistance)
                        return false;
                }
            }
        }

        return true;
    }

    Vector3Int ConvertPosition(Vector2 position)
    {
        return tilemap.WorldToCell(position);
    }

    public void CreateTower(GameObject tower, int cost)
    {
        towerObject = Instantiate(tower, transform);
        radiusCircle = towerObject.GetComponentsInChildren<SpriteRenderer>()[0];

        float radius = towerObject.GetComponent<TowerController>().GetRadius();
        radiusCircle.transform.localScale = new Vector3(radius, radius);

        this.cost = cost;
        towerBought = true;
    }
}

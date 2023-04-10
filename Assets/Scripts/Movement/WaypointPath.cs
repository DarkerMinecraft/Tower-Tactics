using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaypointPath : MonoBehaviour
{

    [SerializeField]
    private Tilemap tilemap;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        int childCount = transform.childCount;

        Gizmos.color = Color.blue;
        for(int i = 0; i < childCount; i++) 
        {
            Vector2 position = tilemap.GetCellCenterWorld(ConvertPosition(transform.GetChild(i).position));

            Gizmos.DrawSphere(position, 0.1f);
        }

        if (childCount >= 2) 
        {
            Gizmos.color = Color.yellow;

            for (int i = 0; i < childCount; i++) 
            {
                for(int j = (i + 1); j < childCount; j++) 
                {
                    Gizmos.DrawLine(tilemap.GetCellCenterWorld(ConvertPosition(transform.GetChild(i).position)),
                        tilemap.GetCellCenterWorld(ConvertPosition(transform.GetChild(j).position)));
                }
            }
        }

    }

    Vector3Int ConvertPosition(Vector2 position) 
    {
        return tilemap.WorldToCell(position);
    }
}

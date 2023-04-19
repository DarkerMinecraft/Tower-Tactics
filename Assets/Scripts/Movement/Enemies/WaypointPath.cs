using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaypointPath : MonoBehaviour
{

    [SerializeField]
    private Tilemap tilemap;

    private Vector2[] waypointPath;

    void Start()
    {
        waypointPath = new Vector2[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) 
        {
            waypointPath[i] = tilemap.GetCellCenterWorld(ConvertPosition(GetWaypoint(i)));
        }
    }

    private void OnDrawGizmos()
    {
        int childCount = transform.childCount;

        Gizmos.color = Color.blue;
        for(int i = 0; i < childCount; i++) 
        {
            Vector2 position = tilemap.GetCellCenterWorld(ConvertPosition(GetWaypoint(i)));

            Gizmos.DrawSphere(position, 0.1f);
        }

        if (childCount >= 2) 
        {
            Gizmos.color = Color.yellow;

            for (int i = 0; i < childCount; i++) 
            {
                Vector2 currentWaypoint = GetWaypoint(i);
                Vector2 nextWaypoint = GetWaypoint(i + 1);

                if(nextWaypoint != Vector2.zero) 
                {
                    currentWaypoint = tilemap.GetCellCenterWorld(ConvertPosition(currentWaypoint));
                    nextWaypoint = tilemap.GetCellCenterWorld(ConvertPosition(nextWaypoint));

                    Gizmos.DrawLine(currentWaypoint, nextWaypoint);
                }
            }
        }
    }

    public Vector2[] GetPath() { return waypointPath; } 

    Vector2 GetWaypoint(int index)
    {
        if(index >= transform.childCount) return Vector2.zero;

        return transform.GetChild(index).transform.position;
    }

    Vector3Int ConvertPosition(Vector2 position) 
    {
        return tilemap.WorldToCell(position);
    }
}

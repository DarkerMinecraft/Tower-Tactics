using System.Collections;
using TMPro;
using UnityEngine;

public class TowerBuyer : MonoBehaviour
{

    [SerializeField]
    private GameObject tower;

    [SerializeField]
    private int cost;

    [SerializeField]
    private TowerPlacer towerPlacer;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "$" + cost.ToString("N0");   
    }

    public void OnClick() 
    {
        if (CoinsChanger.CanChangeCoins(cost)) 
        {
            towerPlacer.CreateTower(tower, cost);
        }
    }
    
}

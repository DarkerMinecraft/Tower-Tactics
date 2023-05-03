using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Towers
{
    public class TowerPricing : MonoBehaviour
    {

        [SerializeField]
        private Price[] prices;

        private static Dictionary<Tower, int> towerPrices;

        private void Awake()
        {
            towerPrices = new Dictionary<Tower, int>();
        }

        private void Start()
        {
            foreach (Price price in prices)
            {
                if (!towerPrices.ContainsKey(price.tower))
                    towerPrices.Add(price.tower, price.price);
            }
        }

        [System.Serializable]
        class Price
        {
            public Tower tower;
            public int price;
        }

        public static int GetTowerPrice(Tower tower) 
        {
            return towerPrices[tower];
        }
    }
}
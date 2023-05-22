using System.Collections;
using Tactics.Enemies;
using Tactics.UI;
using UnityEngine;

namespace Tactics.Assets.Scripts.UI.GameOver
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject towersObj;

        [SerializeField]    
        private GameObject enemiesObj;

        private int startingCash = 675;
        private int startingLives = 200;

        public void onClick() 
        {
            for(int i = 0; i < towersObj.transform.childCount; i++) 
                Destroy(towersObj.transform.GetChild(i).gameObject);

            for(int i = 0; i < enemiesObj.transform.childCount; i++) 
                Destroy(enemiesObj.transform.GetChild(i).gameObject);

            CoinsChanger.SetCoins(startingCash);
            LivesChanger.SetLives(startingLives);
            EnemySpawner.ResetSpawner();
            LivesChanger.isMenuUp = false;

            transform.parent.gameObject.SetActive(false);
        }

    }
}
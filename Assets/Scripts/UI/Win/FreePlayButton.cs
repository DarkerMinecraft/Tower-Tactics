using System.Collections;
using System.Collections.Generic;
using Tactics.Enemies;
using Tactics.UI;
using UnityEngine;

namespace Tactics
{
    public class FreePlayButton : MonoBehaviour
    {
        public void OnClick() 
        {
            gameObject.transform.parent.gameObject.SetActive(false);

            LivesChanger.isMenuUp = false;
            EnemySpawner.isFreePlay = true;
        }
    }
}

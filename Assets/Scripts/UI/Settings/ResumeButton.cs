using System.Collections;
using System.Collections.Generic;
using Tactics.UI;
using UnityEngine;

namespace Tactics
{
    public class ResumeButton : MonoBehaviour
    {
        public void OnClick() 
        {
            LivesChanger.isMenuUp = false;
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}

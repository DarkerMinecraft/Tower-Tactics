using System.Collections;
using UnityEngine;

namespace Tactics.UI.GameOver
{
    public class QuitButton : MonoBehaviour
    {
        public void onClick() 
        {
            Application.Quit();
        }
    }
}
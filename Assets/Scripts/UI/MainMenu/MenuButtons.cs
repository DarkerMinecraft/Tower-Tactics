using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tactics.UI.MainMenu
{
    public class MenuButtons : MonoBehaviour
    {

        public void OnClickQuit() 
        {
            Application.Quit();
        }

        public void OnClickStart() 
        {
            StartCoroutine(LoadScene(1));
        }

        public void OnClickTutorial()
        {
            Application.OpenURL("https://docs.google.com/document/d/1-DK4nflYHyDKYktiXSL4Zl4vX9nqTPHN4Kyu0bGpBE0/edit?usp=sharing");
        }

        public void OnClickReturn() 
        {
            StartCoroutine(LoadScene(0));
        }

        public void OnClickCredits() 
        {
            Application.OpenURL("https://docs.google.com/document/d/1f6KEmSLDk7uUyC23Xy-f8Do0dUxBS9HnQjHGXqEPIqY/edit?usp=sharing");
        }

        IEnumerator LoadScene(int buildIndex)
        {
            yield return SceneManager.LoadSceneAsync(buildIndex);
        }

    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private Color play, duringPlay;

    public void OnClick() 
    {
        if (!enemySpawner.IsPlaying()) 
            enemySpawner.StartWave();
    }

    private void Update()
    {
        if (enemySpawner.IsPlaying()) GetComponent<Button>().image.color = duringPlay;
        else GetComponent<Button>().image.color = play;
    }
}

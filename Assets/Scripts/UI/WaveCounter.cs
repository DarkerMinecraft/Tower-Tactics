
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{

    private static TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public static void SetWaveCounter(int wave)
    {
        if (wave == 0) return;
        textMesh.text = wave.ToString();
    }

}

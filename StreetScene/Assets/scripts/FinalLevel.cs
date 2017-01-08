using UnityEngine;
using System.Collections;

public class FinalLevel : MonoBehaviour {

    [SerializeField]
    private GameObject light;

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private float fadeTime;
    private int drawDepth = -1000;
    private float alpha = 0.0f;
    private int fadeDir = -1;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            light.SetActive(true);
        }
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public void BeginFade(int direction)
    {
        alpha = 0;
        fadeDir = direction;
        StartCoroutine("WaitForQuit");
    }

    IEnumerator WaitForQuit()
    {
        yield return new WaitForSeconds(4);
        Resources.UnloadUnusedAssets();
        Application.LoadLevel(0);
    }
}

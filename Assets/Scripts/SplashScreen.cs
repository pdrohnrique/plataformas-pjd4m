using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadScene("MainMenu");
    }
}

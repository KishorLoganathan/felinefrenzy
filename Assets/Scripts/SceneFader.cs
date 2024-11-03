using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage; // Reference to the UI panel's Image component
    public float fadeDuration = 1f;

    void Start() {

        // Start the game with a fade-in
        StartCoroutine(FadeIn());

    }

    public void FadeToScene(string sceneName) {

        StartCoroutine(FadeOut(sceneName));

    }

    IEnumerator FadeIn() 
    {

        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration) {

            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            fadeImage.color = color;
            yield return null;

        }
    }

    IEnumerator FadeOut(string sceneName) {

        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration) {

            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
            
        }

        // After fade out, load the new scene
        SceneManager.LoadScene(sceneName);
    }
}

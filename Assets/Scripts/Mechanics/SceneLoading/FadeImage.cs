using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public float fadeSpeed = 1f; 

    private Image image;
    private Color originalImage;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        image = GetComponent<Image>();
        originalImage = image.color;
        image.color = new Color(originalImage.r, originalImage.g, originalImage.b, 0);

    }

    private void Update()
    {
        if (sceneLoader.fadeIn == true)
        {
            FadeInLoadingScreen();
        }
        // start fading out on howevery many seconds
        if (sceneLoader.fadeOut == true)
        {
            Invoke("FadeOutLoadingScreen", sceneLoader.loadingScreenLength);
        }
      
    }

    // changes the alpha value every frame to either go to 0 for full transparency or 1 to full solid
    void FadeOutLoadingScreen()
    {
        float transparency = Mathf.Clamp01(image.color.a - (fadeSpeed * Time.deltaTime));
        Color fadedImage = new Color(originalImage.r, originalImage.g, originalImage.b, transparency);
        image.color = fadedImage;
    }

    void FadeInLoadingScreen()
    {
        float transparency = Mathf.Clamp01(image.color.a + (fadeSpeed * Time.deltaTime));
        Color fadedInImage = new Color(originalImage.r, originalImage.g, originalImage.b, transparency);
        image.color = fadedInImage;
    }
}


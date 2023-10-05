using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// class to fade in/out the loading screen
public class FadeImage : MonoBehaviour
{
    public float fadeSpeed = 0.7f; 
    
    private Image image;
    private Color originalImage;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();

        // Gets the loading screen image
        image = GetComponent<Image>();
        originalImage = image.color;
    }

    private void Update()
    {
        // start fading in or fading out
        if (sceneLoader.fadeIn == true)
        {
            FadeInLoadingScreen();
        }
        // start fading out on however many seconds, invoke to not fade out instantly
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


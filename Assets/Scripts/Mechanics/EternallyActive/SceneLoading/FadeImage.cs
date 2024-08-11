using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// class to fade in/out the loading screen
public class FadeImage : MonoBehaviour
{
    public float fadeSpeed;
    public float fadeOutSpeed;
    
    
    private Image image;
    private Color originalImage;
    public Image loadingImage;
    private Color originalLoadingImage;

    [SerializeField] private SelectCharacter selectCharacter;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        selectCharacter.selectCharacter();

        // Gets the loading screen image
        image = GetComponent<Image>();
        originalImage = image.color;
        image.color = new Color(image.color.r, image.color.b, image.color.g, 0f);

        originalLoadingImage = loadingImage.color;
        loadingImage.color = new Color(loadingImage.color.r, loadingImage.color.b, loadingImage.color.g, 0f);
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
            //Invoke("FadeOutLoadingScreen", sceneLoader.loadingScreenLength);
            Invoke("FadeOutLoadingScreen", 4f);
        }
    }

    // changes the alpha value every frame to either go to 0 for full transparency or 1 to full solid
    void FadeOutLoadingScreen()
    {
        float transparency = Mathf.Clamp01(image.color.a - (fadeOutSpeed * Time.deltaTime));
        Color fadedImage = new Color(originalImage.r, originalImage.g, originalImage.b, transparency);
        image.color = fadedImage;
        fadedImage = new Color(originalLoadingImage.r, originalLoadingImage.g, originalLoadingImage.b, transparency);
        loadingImage.color = fadedImage;
    }

    void FadeInLoadingScreen()
    {
        float transparency = Mathf.Clamp01(image.color.a + (fadeSpeed * Time.deltaTime));
        Color fadedInImage = new Color(originalImage.r, originalImage.g, originalImage.b, transparency);
        image.color = fadedInImage;
        fadedInImage = new Color(originalLoadingImage.r, originalLoadingImage.g, originalLoadingImage.b, transparency);
        loadingImage.color = fadedInImage;
    }
}


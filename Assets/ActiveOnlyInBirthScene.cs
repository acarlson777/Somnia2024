using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ActiveOnlyInBirthScene : MonoBehaviour {

  public static Dictionary<string,GameObject> instances = new();


  public Scene scene;


  private void Awake() {
    bool ours = instances.ContainsKey(name);
    if(ours){
        Destroy(gameObject);
    }else{
      instances.Add(name,gameObject);
      DontDestroyOnLoad(gameObject);
    }
      // It is save to remove listeners even if they
      // didn't exist so far.
      // This makes sure it is added only once
      SceneManager.sceneLoaded -= OnSceneLoaded;

      // Add the listener to be called when a scene is loaded
      SceneManager.sceneLoaded += OnSceneLoaded;

      scene = SceneManager.GetActiveScene();

  }

  private void OnDestroy(){
    // Always clean up your listeners when not needed anymore
    SceneManager.sceneLoaded -= OnSceneLoaded;

  }
  // Listener for sceneLoaded
  private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
    Debug.LogError("scene loaded: " + scene.name);

    Debug.LogError("New" + scene.path);
    Debug.LogError("Original" + this.scene.path);

    if(!string.Equals(scene.path, this.scene.path)){
      Debug.LogError("Other scene!");
      this.gameObject.SetActive(false);
      this.gameObject.transform.position = new Vector3(-15,3,13);
    }else{
      Debug.LogError("Original BOBweerqaweq3e=0q2ieopqwieuoq2enkb,qwbejkwhvdr scene!!!");
      this.gameObject.SetActive(true);
      this.gameObject.transform.position = new Vector3(-13,3,13);

    }

    Debug.LogError("DONE!!!");
  }
}

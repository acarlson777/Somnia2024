using UnityEngine;
using System.Collections;

public class RoomSwitchInZone : MonoBehaviour
{
    private string sceneName;
    private int switchCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SceneSwapZone") && switchCount == 0)
        {
            sceneName = other.gameObject.GetComponent<NextSceneName>().nextSceneName;
            InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
            switchCount++;
        }
    }
}

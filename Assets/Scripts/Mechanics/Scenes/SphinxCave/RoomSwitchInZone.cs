using UnityEngine;
using System.Collections;

public class RoomSwitchInZone : MonoBehaviour
{
    public string sceneName;
    private bool switched;

    private void OnTriggerEnter(Collider other)
    {
        if (switched) return;
        if (other.gameObject.tag != "entity") return;
        Player script = other.gameObject.GetComponent<Player>();
        if (script == null) return;

        InstantiateLoadingScreen.Instance.LoadNewScene(sceneName);
        switched=true;
        
    }
}

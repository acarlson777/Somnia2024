using UnityEngine;
using System.Collections;

public class MazeGate : InteractableObject, Entity
{
    private Vector3 startPos;
    public float gateSpeed = 1.0f;
    public float gateEndDistance = 3.0f;
    private Vector3 endPos;
    public string audioName;

    [SerializeField]private bool open = false;

    public new void Start()
    {
        base.Start();
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + gateEndDistance, startPos.z);
    }

    public new void Update()
    {
        base.Update();
        if (open)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * gateSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * gateSpeed);
        }
    }

    public new void Interact(Entity entity)
    {

    }

    public void OpenGate()
    {
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce(audioName, gameObject);
        open = true;
    }
    public void CloseGate()
    {
        open = false;
    }
}
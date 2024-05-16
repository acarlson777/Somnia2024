using UnityEngine;
using System.Collections;

public class PasswordSymbol: InteractableObject, Entity
{

    [SerializeField] private bool lit = false;
    public string symbol = "";
    public Material startingMat;
    public Material onMat;
    public string audioName;

    private Vector3 startPos;
    private Vector3 endPos;
    public float symbolSpeed = 1.0f;
    [SerializeField] public float symbolEndDistance = -0.5f;

    public new void Start(){
        base.Start();
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + symbolEndDistance, startPos.z);
        startingMat = gameObject.GetComponent<Renderer>().material;
    }

    public new void Update()
    {
        base.Update();

        if (lit)
        {
            // Move down so that half is showing
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * symbolSpeed);
        }
        else
        {
            // Move back up so that all is showing
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * symbolSpeed);
        }
    }
    public bool getLit()
    {
        // to tell the submit button to add the symbols that are lit
        return lit;
    }
    public new void Interact(Entity entity)
    {
        // if the player has interacted with us then just light on or off!
        AudioManagerSingleton.Instance.PlayRandomSongFromSoundtrackOnce(audioName, gameObject);
        lit = !lit;
        if (lit)
        {

          print("LIT");
            //gameObject.GetComponent<Renderer>().material = onMat;
            //Move down so that half is showing
            // transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * symbolSpeed);

            print(startPos.x + " " + startPos.y + " " +  symbolEndDistance + " " + startPos.z);
        }
        else
        {

          print("NOT LIT");
            // unlights itself after second interaction
            //gameObject.GetComponent<Renderer>().material = startingMat;
            //move back up so that all is showing
            // transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * symbolSpeed);
            print(endPos.x + " " + endPos.y + " " + endPos.z);
        }
    }
}

using UnityEngine;
using System.Collections;

public class ResetSphinx : MonoBehaviour
{
    void Start()
    {
        Sphinx.timesInteracted = 0;
    }
}

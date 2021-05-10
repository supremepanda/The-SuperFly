using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    // Initializing warning text object.
    [SerializeField] private GameObject _warningText;

    private void OnTriggerEnter(Collider collision)
    {
        // Activating warning text object.
        if(collision.gameObject.tag == "Border") { _warningText.SetActive(true); }
    }

    private void OnTriggerExit(Collider collision)
    {
        // De-activating warning text object.
        if(collision.gameObject.tag == "Border") { _warningText.SetActive(false); }    
    }

}

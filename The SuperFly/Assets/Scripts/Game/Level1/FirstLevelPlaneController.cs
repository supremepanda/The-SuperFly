using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelPlaneController : MonoBehaviour
{
    #region Color

    // Initializing plane material component as reachable from editor.
    [SerializeField] private Material _planeMaterial = null;

    // Initializing left trail component.
    private TrailRenderer _trailLeft = null;

    // Initializing right trail component.
    private TrailRenderer _trailRight = null;

    /// <summary>
    /// It changes colors of plane and trail effects.
    /// </summary>
    /// <param name="other">Color trigger Collider</param>
    private void ChangeColors(Collider other)
    {
        // New color is trigger field color to change plane color
        Color newColor = other.GetComponent<MeshRenderer>().material.color;

        // Changing plane material color
        _planeMaterial.color = newColor;

        // Changing plane trail effect left side color
        _trailLeft.startColor = newColor;
        _trailLeft.endColor = newColor;

        // Changing plane trail effect right side color
        _trailRight.startColor = newColor;
        _trailRight.endColor = newColor;
    }

    #endregion

    // Initializing StartLevelHUD component.
    private FirstLevelManager _manager = null;

    #region Audio

    // Initializing AudioSource component.
    private AudioSource _audio;

    // Initializing AudioClip for triggering effect of Color trigger.
    [SerializeField] private AudioClip _triggerFx;
    #endregion

    private void Start()
    {
        // Cursor should not be showed in plane scenes.
        Cursor.visible = false;

        // Getting AudioSource component of Plane object
        _audio = GetComponent<AudioSource>();

        // Getting Trail Renderer Component of TrailLeft gameobject.
        _trailLeft = transform.Find("TrailLeft").GetComponent<TrailRenderer>();

        // Getting Trail Renderer Component of TrailRight gameobject.
        _trailRight = transform.Find("TrailRight").GetComponent<TrailRenderer>();

        // Getting StartLevelHUD component of HUDController.
        _manager = GameObject.Find("Level 1 Manager").GetComponent<FirstLevelManager>();

        // Creating color from plane material.
        Color planeMatColor = _planeMaterial.color;

        // Setting left trail start color from plane material.
        _trailLeft.startColor = planeMatColor;

        // Setting left trail end color from plane material.
        _trailLeft.endColor = planeMatColor;

        // Setting right trail start color from plane material.
        _trailRight.startColor = planeMatColor;

        // Setting right trail end color from plane material.
        _trailRight.endColor = planeMatColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If plane triggers ColorTrigger gameobjects;
        if (other.gameObject.tag == "ColorTrigger" && other.GetComponent<ColorTrigger>().GetIsTriggered() == false)
        {
            // Setting color trigger object as is triggered.
            other.GetComponent<ColorTrigger>().SetIsTriggered(true);

            // To chane plane color
            ChangeColors(other);

            // Decreasing pipe amount.
            _manager.DecreaseRemainingPipe();

            // Playing color trigger audio effect.
            _audio.PlayOneShot(_triggerFx, 1f);
        }

    }
}

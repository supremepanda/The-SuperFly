using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelPlane : MonoBehaviour
{
    #region Color

    // Initializing plane material component as reachable from editor.
    [SerializeField] private Material _planeMaterial = null;

    // Initializing left trail component.
    private TrailRenderer _trailLeft = null;

    // Initializing right trail component.
    private TrailRenderer _trailRight = null;

    /// <summary>
    /// It changes color trigger colors after given time and it sets color trigger as is not triggered.
    /// </summary>
    /// <param name="randomColor">Created new random color</param>
    /// <param name="other">Color trigger collider</param>
    /// <returns>WaitForSeconds</returns>
    private IEnumerator ChangeColorWithSomeTime(Color randomColor, Collider other)
    {
        // It waits up to given seconds.
        yield return new WaitForSeconds(1f);

        // Assigning new randomized color to color trigger material.
        other.GetComponent<MeshRenderer>().material.color = randomColor;

        // Setting color triggered as is not triggered.
        other.GetComponent<ColorTrigger>().SetIsTriggered(false);

    }

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

        // Creating random color to assign new color to trigger field
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            0.117f);

        // Starting given Coroutine
        StartCoroutine(ChangeColorWithSomeTime(randomColor, other));
    }
    #endregion

    // Initializing StartLevelHUD component.
    private LevelHUD _hud = null;

    #region Audio

    // Initializing AudioSource component.
    private AudioSource _audio;

    // Initializing AudioClip for triggering effect of Color trigger.
    [SerializeField] private AudioClip _triggerFx;
    #endregion

    // If the plane stuck, reset position will help.
    private Vector3 _resetPosition = new Vector3(16f, 28f, -53f);

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
        _hud = GameObject.Find("HUDController").GetComponent<LevelHUD>();

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = _resetPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If plane triggers ColorTrigger gameobjects;
        if (other.gameObject.tag == "ColorTrigger" && other.GetComponent<ColorTrigger>().GetIsTriggered() == false)
        {
            // Setting color trigger object as is triggered.
            other.GetComponent<ColorTrigger>().SetIsTriggered(true);

            // Playing color trigger audio effect.
            _audio.PlayOneShot(_triggerFx, 1f);

            // To changing plane and trail colors.
            ChangeColors(other);

            // Increasing count values of left pipe.
            if (other.gameObject.transform.parent.gameObject.name == "LeftPipe") { _hud.IncreaseCountLeftPipe(); }

            // Increasing count values of right pipe.
            else if (other.gameObject.transform.parent.gameObject.name == "RightPipe")
            {
                _hud.IncreaseCountRightPipe();
            }
        }

    }
}
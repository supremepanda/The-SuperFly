using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevelPlaneController : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _triggerFx;
    [SerializeField] private AudioClip _laserFx;

    #region Color

    private string _colorTag;

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
        _colorTag = other.GetComponent<ColorTag>().GetColorTag();

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

    #region Fire
    [SerializeField] private Transform _leftSpawnPos;
    [SerializeField] private Transform _rightSpawnPos;

    [SerializeField] private GameObject _bullet;

    private void Fire()
    {
        _audio.PlayOneShot(_laserFx, 1f);
        GameObject bullet1 = Instantiate(_bullet, _leftSpawnPos.position, _leftSpawnPos.rotation);
        bullet1.GetComponent<Bullet>().SetColorTag(_colorTag);

        GameObject bullet2 = Instantiate(_bullet, _rightSpawnPos.position, _rightSpawnPos.rotation);
        bullet2.GetComponent<Bullet>().SetColorTag(_colorTag);
    }

    #endregion

    private bool _isPowercellTriggered = false;

    private ThirdLevelManager _manager;

    private bool _isTriggered = false;

    private void Start()
    {
        // Cursor should not be showed in plane scenes.
        Cursor.visible = false;

        // Getting AudioSource component of AudioManager
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();

        // Getting Trail Renderer Component of TrailLeft gameobject.
        _trailLeft = transform.Find("TrailLeft").GetComponent<TrailRenderer>();

        // Getting Trail Renderer Component of TrailRight gameobject.
        _trailRight = transform.Find("TrailRight").GetComponent<TrailRenderer>();

        // Getting StartLevelHUD component of HUDController.
        _manager = GameObject.Find("Level 3 Manager").GetComponent<ThirdLevelManager>();

        // Creating white color.
        Color planeMatColor = new Color(1, 1, 1, 1);

        _planeMaterial.color = planeMatColor;

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
        if (ThirdLevelManager.isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ColorTrigger" && !_isTriggered)
        {
            _isTriggered = true;
            ChangeColors(other);
            _audio.PlayOneShot(_triggerFx, 1f);
            StartCoroutine(ChangeIsTriggered());

        }
        else if(other.gameObject.tag == "powercell" && !_isPowercellTriggered)
        {
            Destroy(other.gameObject);
            _manager.FinishGame();
        }
    }

    private IEnumerator ChangeIsTriggered()
    {
        yield return new WaitForSeconds(1f);
        _isTriggered = false;
    }



}

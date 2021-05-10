using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket3 : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _explosion;

    private Rigidbody _rb;
    [SerializeField] private float _speed;

    private Transform _planeVec;

    private bool _isCollided = false;

    private ThirdLevelManager _manager;

    private void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        _manager = GameObject.Find("Level 3 Manager").GetComponent<ThirdLevelManager>();
        _planeVec = GameObject.Find("Player").transform.GetChild(0).transform.GetChild(0);
        _rb = GetComponent<Rigidbody>();
        transform.LookAt(_planeVec);
        Debug.Log(transform.forward);
        _rb.velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" && !_isCollided)
        {
            _audio.PlayOneShot(_explosion, 1f);
            _isCollided = true;
            _rb.velocity = Vector3.zero;
            _manager.DecreaseHealthAmount();
            GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}

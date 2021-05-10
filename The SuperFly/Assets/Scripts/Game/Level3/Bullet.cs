using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _hitEffect;

    private float _deadTime = 5f;

    private string _colorTag;

    public string GetColorTag()
    {
        return _colorTag;
    }

    public void SetColorTag(string newTag)
    {
        _colorTag = newTag;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity =  transform.up * _speed;
    }

    private void Update()
    {
        if(_deadTime > 0) { _deadTime -= Time.deltaTime; }
        else { Destroy(gameObject); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Instantiate(_hitEffect, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

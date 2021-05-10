using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPipe : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    public void SetSpeed(float value)
    {
        _speed = value;
        _rigidbody.velocity = Vector3.right * _speed;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.right * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HorizontalTrigger")
        {
            _speed = -_speed;
            _rigidbody.velocity = Vector3.right * _speed;
        }
    }
}

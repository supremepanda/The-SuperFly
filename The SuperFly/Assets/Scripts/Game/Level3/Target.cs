using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private ThirdLevelManager _manager;
    [SerializeField] private string _targetColor;

    private void Start()
    {
        _manager = GameObject.Find("Level 3 Manager").GetComponent<ThirdLevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);

        if (collision.gameObject.tag == "bullet" &&
            collision.gameObject.GetComponent<Bullet>().GetColorTag() == _targetColor)
        {
            _manager.PlayHitFx();
            _manager.DecreaseCastleHealth(_targetColor);    
        }
    }
}
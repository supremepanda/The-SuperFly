using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private float _destroyTime;

    private void Update()
    {
        if(_destroyTime > 0) { _destroyTime -= Time.deltaTime; }
        else { Destroy(gameObject); }
    }
}

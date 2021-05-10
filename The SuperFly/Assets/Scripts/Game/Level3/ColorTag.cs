using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTag : MonoBehaviour
{
    [SerializeField] private string _colorTag;

    public string GetColorTag()
    {
        return _colorTag;
    }
}

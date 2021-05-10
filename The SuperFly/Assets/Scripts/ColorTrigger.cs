using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    // To control is triggered before.
    private bool _isTriggered = false;

    /// <summary>
    /// Getter function of _isTriggered value.
    /// </summary>
    /// <returns>_isTriggered</returns>
    public bool GetIsTriggered()
    {
        return _isTriggered;
    }

    /// <summary>
    /// Setter function of _isTriggered value
    /// </summary>
    /// <param name="value">boolean istriggered value</param>
    public void SetIsTriggered(bool value)
    {
        _isTriggered = value;
    }
}

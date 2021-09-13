using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancingBehavior : MonoBehaviour
{
    public void OnInstance(GameObject newInstance)
    {
        Instantiate((newInstance));
    }
}

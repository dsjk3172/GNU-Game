using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform land;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = land.position;
        other.transform.Translate(0, 0, -15);
    }
}

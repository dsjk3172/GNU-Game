using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionType : MonoBehaviour
{
    public bool isNPC;
    public bool isObject;
    public bool isBuilding;

    [SerializeField] string interactiononName;

    public string GetName()
    {
        return interactiononName;
    }
}

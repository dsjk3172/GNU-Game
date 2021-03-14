using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    [SerializeField] float disapperTime;

    private void OnEnable()
    {
        StartCoroutine(DisappearCoroutine());
    }

    IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(disapperTime);

        gameObject.SetActive(false);
    }
}

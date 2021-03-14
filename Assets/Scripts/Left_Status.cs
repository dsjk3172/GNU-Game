using System;
using UnityEngine;
using UnityEngine.UI;

public class Left_Status : MonoBehaviour
{
    [SerializeField] Text txt_Date;
    [SerializeField] Text txt_Time;

    void Update()
    {
        txt_Date.text = DateTime.Now.ToString(("yyyy-MM-dd"));
        txt_Time.text = DateTime.Now.ToString(("HH:mm:ss tt"));
    }
}
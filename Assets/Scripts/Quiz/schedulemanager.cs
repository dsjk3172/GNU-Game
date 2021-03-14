using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class schedulemanager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Schedule;
    public GameObject scroll;
    GameObject subject;
    public List<GameObject> subjectList = new List<GameObject>();

    InteractionController theIC;
    void Start()
    {
        theIC = FindObjectOfType<InteractionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("q"))
        {
            Schedule.SetActive(true);
            theIC.SettingUI(false);
        }

    }
    public void setactive1(int i)
    {
        for (int h = i; h < i+4; h++)
            subjectList[h].SetActive(false);
        subjectList[i].SetActive(true);
    }
    public void setactive2(int i)
    {
        for (int h = i; h < i + 4; h++)
            subjectList[h].SetActive(false);
        subjectList[i+1].SetActive(true);
    }
    public void setactive3(int i)
    {
        for (int h = i; h < i + 4; h++)
            subjectList[h].SetActive(false);
        subjectList[i+2].SetActive(true);
    }
    public void setactive4(int i)
    {
        for (int h = i; h < i + 4; h++)
            subjectList[h].SetActive(false);
        subjectList[i+3].SetActive(true);
    }
    public void setactive5(int i)
    {
        for (int h = i; h < i + 3; h++)
            subjectList[h].SetActive(false);
        subjectList[i].SetActive(true);
    }
    public void setactive6(int i)
    {
        for (int h = i; h < i + 3; h++)
            subjectList[h].SetActive(false);
        subjectList[i+1].SetActive(true);
    }
    public void setactive7(int i)
    {
        for (int h = i; h < i + 3; h++)
            subjectList[h].SetActive(false);
        subjectList[i+2].SetActive(true);
    }

    public void delete(int i)
    {
        subjectList[i].SetActive(false);
    }

    public void scrollActive()
    {
        scroll.SetActive(true);
    }

    public void scrollDeActive()
    {
        scroll.SetActive(false);
    }
    public void close()
    {
        theIC.SettingUI(true);
        Schedule.SetActive(false);
    }
    
}

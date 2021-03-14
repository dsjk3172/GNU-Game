using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionActive : MonoBehaviour

{
    // Start is called before the first frame update

    public List<GameObject> subjectList = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        for (int i = 0; i<subjectList.Count; i++)
            subjectList[i].SetActive(true);
    }
}

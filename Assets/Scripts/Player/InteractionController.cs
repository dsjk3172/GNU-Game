using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [SerializeField] Camera cam;

    RaycastHit hitInfo;

    [SerializeField] GameObject go_NormalCrosshair;
    [SerializeField] GameObject go_InteractiveCrosshair;
    [SerializeField] GameObject go_Crosshair;
    [SerializeField] GameObject go_Cursor;
    [SerializeField] GameObject go_TargetNamebar;
    [SerializeField] Text txt_TargetName;
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] Text txt_Dialogue;

    bool isContact = false;
    public static bool isInteract = false;

    [SerializeField] ParticleSystem ps_QuestionEffect;

    DialogManager theDM;

    public void SettingUI(bool p_flag)
    {
        go_Crosshair.SetActive(p_flag);
        go_Cursor.SetActive(p_flag);
        go_TargetNamebar.SetActive(p_flag);

        isInteract = !p_flag;
    }

    void Start()
    {
        theDM = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInteract)
        {
            CheckObject();
            ClickLeftBtn();
        }
    }

    void CheckObject()
    {
        Vector3 t_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (Physics.Raycast(cam.ScreenPointToRay(t_MousePos), out hitInfo, 100))
        {
            Contact();
        }
        else
        {
            NotContact();
        }
    }

    void Contact()
    {
        if (hitInfo.transform.CompareTag("Interaction") && hitInfo.transform.GetComponent<InteractionType>().isNPC == true)
        {
            go_TargetNamebar.SetActive(true);
            txt_TargetName.text = hitInfo.transform.GetComponent<InteractionType>().GetName();
            if (!isContact)
            {
                isContact = true;
                go_InteractiveCrosshair.SetActive(true);
                go_NormalCrosshair.SetActive(false);
            }
        }

        else if(hitInfo.transform.CompareTag("Interaction") && hitInfo.transform.GetComponent<InteractionType>().isObject == true)
        {
            go_TargetNamebar.SetActive(true);
            txt_TargetName.text = hitInfo.transform.GetComponent<InteractionType>().GetName();
        }

        else if (hitInfo.transform.CompareTag("Interaction") && hitInfo.transform.GetComponent<InteractionType>().isBuilding == true)
        {
            go_DialogueBar.SetActive(true);
            txt_Dialogue.text = hitInfo.transform.GetComponent<InteractionType>().GetName();
        }

        else
        {
            NotContact();
        }
    }

    void NotContact()
    {
        go_TargetNamebar.SetActive(false);
        go_DialogueBar.SetActive(false);
        isContact = false;
        go_InteractiveCrosshair.SetActive(false);
        go_NormalCrosshair.SetActive(true);
    }

    void ClickLeftBtn()
    {
        if (!isInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isContact)
                    Interact();
            }
        }
    }

    void Interact()
    {
        isInteract = true;

        ps_QuestionEffect.gameObject.SetActive(true);
        Vector3 t_targetPos = hitInfo.transform.position;
        ps_QuestionEffect.GetComponent<QuestionEffect>().SetTarget(t_targetPos);
        ps_QuestionEffect.transform.position = cam.transform.position;

        StartCoroutine(WaitCollision());
    }

    IEnumerator WaitCollision()
    {
        yield return new WaitUntil(()=>QuestionEffect.isCollide);
        QuestionEffect.isCollide = false;

        theDM.ShowDialogue(hitInfo.transform.GetComponent<InteractionEvent>().GetDialogue());
    }
}
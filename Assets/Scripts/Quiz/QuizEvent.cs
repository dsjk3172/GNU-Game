using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Quiz;
    public GameObject Problem;
    public GameObject Subject;
    public GameObject Correct;
    public GameObject InCorrect;

    InteractionController theIC;

    void Start()
    {
        theIC = FindObjectOfType<InteractionController>();
    }
    private void OnMouseDown()
    {
        StartCoroutine(WaitCollision());

    }

        IEnumerator WaitCollision()
    {
        yield return new WaitUntil(() => QuestionEffect.isCollide);
        QuestionEffect.isCollide = false;

        Quiz.SetActive(true);
        Problem.SetActive(true);
        theIC.SettingUI(false);
    }
    public void correct()
    {
        Problem.SetActive(false);
        Subject.SetActive(true);
        Correct.SetActive(true);
    }

    public void incorrect()
    {
        Problem.SetActive(false);
        InCorrect.SetActive(true);
    }

    public void OK()
    {
        Correct.SetActive(false);
        Quiz.SetActive(false);
        theIC.SettingUI(true);
    }

    public void OK2()
    {
        InCorrect.SetActive(false);
        Quiz.SetActive(false);
        theIC.SettingUI(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image portrait;

    [Range(0f, 1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;

    DialogueContainer currentDialogue;

    int currentTextLine;

    float totalTimeTyping, currentTime;

    string lineToShow;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
        }

        TypeOutText();
    }

    //Progress the timer and type the text on screen
    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f) return;

        currentTime += Time.deltaTime;

        //Calculates the total amount of letters to show
        visibleTextPercent = currentTime / totalTimeTyping;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0, 1f);

        UpdateText();
    }

    private void UpdateText()
    {
        //null
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    private void PushText()
    {
        if(visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }

        if(currentTextLine >= currentDialogue.lines.Count)
        {//null
            Conclude();
        } else
        {
            CycleLine();
  
        }
    }

    public void CycleLine()
    {
        lineToShow = currentDialogue.lines[currentTextLine];
        totalTimeTyping = lineToShow.Length * timePerLetter;
        currentTime = 0f; //clears text object by resetting itself
        visibleTextPercent = 0f;
        targetText.text = "";

        currentTextLine += 1;
    }

    private void UpdatePortrait()
    {
        portrait.sprite = currentDialogue.actor.portrait;
        nameText.text = currentDialogue.actor.Name;
    }

    public void InitializeDialogue(DialogueContainer _dc)
    {
        Display(true);
        currentDialogue = _dc;
        currentTextLine = 0;
        CycleLine();
        UpdatePortrait();
    }

    private void Display(bool b)
    {
        gameObject.SetActive(b);
    }

    private void Conclude()
    {
        Debug.Log("Dialogue ended");
        Display(false);
    }
}

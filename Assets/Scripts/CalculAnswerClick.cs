using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CalculAnswerClick : CalculHeritage
{
    public Color colorWrong;
    public Color colorCorrect;

    public float newCalculDelay;

    public void Answer(int id)
    {
        Answer_Color(id);
        Answer_DisableButtons(id);
        StartCoroutine(NewCalculDelay());
    }

    void Answer_Color(int id)
    {
        if (calculRandom.answerCorrect == id) answerImageList[id].color = colorCorrect;
        else answerImageList[id].color = colorWrong;
    }

    void Answer_DisableButtons(int id)
    {
        foreach (Button btn in answerButtonList)
        {
            btn.enabled = false;
        }
    }

    IEnumerator NewCalculDelay()
    {
        yield return new WaitForSeconds(newCalculDelay);
        calculRandom.NewCalcul();
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculAnswerClick : CalculHeritage
{
    public Color colorWrong;
    public Color colorCorrect;

    public float newCalculDelay;

    public void Answer(Image obj)
    {
        Answer_Color(obj);
        Answer_DisableButtons();
        StartCoroutine(NewCalculDelay());
    }

    void Answer_Color(Image obj)
    {
        if (obj == answerImageList[calculRandom.answerCorrect]) obj.color = colorCorrect;
        else obj.color = colorWrong;
    }

    void Answer_DisableButtons()
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

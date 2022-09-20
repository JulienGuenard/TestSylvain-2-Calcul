using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculRandom : CalculHeritage
{
    [HideInInspector] public int answerCorrect;

    int nb1;
    int nb2;
    string sign;
    float result;
    string calculTxt;

    override public void Awake()
    {
        base.Awake();
        NewCalcul();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewCalcul();
        }
    }

    public void NewCalcul()
    {
        NewCalcul_Reset();
        NewCalcul_RandomGeneration();
        NewCalcul_FindResult();
        NewCalcul_GenerateAnswers();
    }

    void NewCalcul_Reset()
    {
        foreach (Image img in answerImageList)
        {
            img.color = Color.white;
        }

        foreach (Button btn in answerButtonList)
        {
            btn.enabled = true;
        }
    }

    void NewCalcul_RandomGeneration()
    {
        nb1 = Random.Range(1, 10);
        nb2 = Random.Range(1, 10);

        switch (Random.Range(1, 4))
        {
            case 1: sign = " + "; break;
            case 2: sign = " - "; break;
            case 3: sign = " * "; break;
            case 4: sign = " / "; break;
        }
    }

    void NewCalcul_FindResult()
    {
        result = 0;
        calculTxt = "Combien font " + nb1.ToString() + sign + nb2.ToString() + " ?";

        switch (sign)
        {
            case " + ": result = nb1 + nb2; break;
            case " - ": result = nb1 - nb2; break;
            case " * ": result = nb1 * nb2; break;
            case " / ": result = nb1 / nb2; break;
        }

        answerCorrect = Random.Range(0, answerList.Count - 1);
    }

    void NewCalcul_GenerateAnswers()
    {
        List<float> allCalcul = new List<float>();

        for (int i = 0; i < answerList.Count; i++)
        {
            float calcul = 0;
            while (calcul == result || allCalcul.Contains(calcul))
            {
                calcul = result + Random.Range(-10, 10);
            }

            if (answerCorrect == i) calcul = result;

            allCalcul.Add(calcul);
            answerList[i].text = calcul.ToString();
        }

        enonce.text = calculTxt;
    }
}

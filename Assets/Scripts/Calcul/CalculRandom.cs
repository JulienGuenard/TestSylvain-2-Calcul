using System.Collections;
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

    List<string> calculHistoric = new List<string>();
    List<string> resultHistoric = new List<string>();

    public List<AudioClip> numberSFXList;
    public AudioClip signSFX;

    override public void Awake()
    {
        base.Awake();
        NewCalcul();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NewCalcul();
        }
    }

    public void NewCalcul()
    {
        NewCalcul_WriteHistoric();
        NewCalcul_Reset();
        NewCalcul_RandomGeneration();
        StartCoroutine(NewCalcul_EnonceSFX());
        NewCalcul_FindResult();
        NewCalcul_GenerateAnswers();
    }

    void NewCalcul_WriteHistoric()
    {
        if (calculHistoric.Count == 0) return;

        string newTxt = "";

        for(int i = 0; i < calculHistoric.Count; i++)
        {
            newTxt += i.ToString() + ": " + calculHistoric[i] + " = " + resultHistoric[i] + "<br>";
                    }
        historic.text = newTxt;
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
        int new_nb1 = 0;
        int new_nb2 = 0;
        do
        {
            new_nb1 = Random.Range(1, 11);
            new_nb2 = Random.Range(1, 11);
        }
        while (new_nb1 == nb1 && new_nb2 == nb2);

        nb1 = new_nb1;
        nb2 = new_nb2;

        switch (Random.Range(3, 4))
        {
            case 1: sign = " + "; break;
            case 2: sign = " - "; break;
            case 3: sign = " * "; break;
            case 4: sign = " / "; break;
        }
    }

    IEnumerator NewCalcul_EnonceSFX()
    {
        audioS.PlayOneShot(numberSFXList[nb1]);
        yield return new WaitForSeconds(numberSFXList[nb1].length - 0.1f);
        audioS.PlayOneShot(signSFX, 1.3f);
        yield return new WaitForSeconds(signSFX.length);
        audioS.PlayOneShot(numberSFXList[nb2]);
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
            case " / ": result = (float)nb1 / (float)nb2; break;
        }
        answerCorrect = Random.Range(0, answerList.Count);
    }

    void NewCalcul_GenerateAnswers()
    {
        List<float> allCalcul = new List<float>();

        for (int i = 0; i < answerList.Count; i++)
        {
            float calcul = 0;
            do
            {
                calcul = result + Random.Range(-10, 10);
            } while (calcul == result || allCalcul.Contains(calcul));

                if (answerCorrect == i) calcul = result;

            allCalcul.Add(calcul);
            answerList[i].text = calcul.ToString();
        }

        enonce.text = calculTxt;

        calculHistoric.Add(calculTxt);
        resultHistoric.Add(result.ToString());
    }
}

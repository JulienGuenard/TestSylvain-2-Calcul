using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalculHeritage : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI enonce;
    [HideInInspector] public List<TextMeshProUGUI> answerList = new List<TextMeshProUGUI>();
    [HideInInspector] public List<Image> answerImageList = new List<Image>();
    [HideInInspector] public List<Button> answerButtonList = new List<Button>();
    [HideInInspector] public TextMeshProUGUI historic;

    [HideInInspector] public CalculRandom calculRandom;

    virtual public void Awake()
    {
        enonce = GameObject.FindGameObjectWithTag("enonce").GetComponent<TextMeshProUGUI>();
        historic = GameObject.FindGameObjectWithTag("historic").GetComponent<TextMeshProUGUI>();
        foreach (GameObject answer in GameObject.FindGameObjectsWithTag("answer"))
        {
            answerList.Add(answer.GetComponentInChildren<TextMeshProUGUI>());
            answerImageList.Add(answer.GetComponent<Image>());
            answerButtonList.Add(answer.GetComponent<Button>());
        }

        calculRandom = GetComponent<CalculRandom>();
    }
}

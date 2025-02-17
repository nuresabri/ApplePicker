using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        uiText.text = score.ToString("#,0");
    }
}

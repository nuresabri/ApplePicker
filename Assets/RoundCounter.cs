using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{

    [Header("Dynamic")]
    public int currentRound = 1;

    public Text uiText;

    public float roundDuration = 20f;

    private bool gameRunning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RoundTimer());
        UpdateRoundText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateRoundText(){
        uiText.text = "Round: " + currentRound;
    }

    private IEnumerator RoundTimer(){
        while(gameRunning){
            yield return new WaitForSeconds(roundDuration);

            if(currentRound < 4){
                currentRound++;
                UpdateRoundText();
            }
        }
    }

    public void EndGame(){
        gameRunning = false;
    }
}

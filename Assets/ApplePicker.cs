using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ApplePicker : MonoBehaviour
{
    [Header ("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public GameObject gameOverScreen;

    public List<GameObject> basketList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; ++i){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        
    }

    public void StickMissed(){
        GameObject[] stickArray = GameObject.FindGameObjectsWithTag("Stick");
        foreach(GameObject tempGO in stickArray){
            Destroy(tempGO);
        }
    }

    public void AppleMissed(){
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }

        GameObject[] stickArray = GameObject.FindGameObjectsWithTag("Stick");
        foreach(GameObject tempGO in stickArray){
            Destroy(tempGO);
        }
        
        int basketIndex = basketList.Count -1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0){
            SceneManager.LoadScene("GameOver");
        }
    }

    public void StickHit(){
        GameObject[] stickArray = GameObject.FindGameObjectsWithTag("Stick");
        foreach(GameObject tempGO in stickArray){
            Destroy(tempGO);
            
            SceneManager.LoadScene("GameOver");
        }

    }

    
    public void restart(){
        SceneManager.LoadScene("_Scene_0");
    }

}

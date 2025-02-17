using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    void Start()
    {
        GameObject ScoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = ScoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get current current screen position of mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's x position sets how far to push the mouse into 3D
        //If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to Main Camera int he Inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2d Screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move x pos of this basket to the x position of the mouse

    Vector3 pos = this.transform.position;
    pos.x = mousePos3D.x;
    this.transform.position = pos;
        
    }
    void OnCollisionEnter(Collision coll){
        //Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);

            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }

        if (collidedWith.CompareTag("Stick")){
            Destroy(collidedWith);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.StickHit();

        }
    }
}

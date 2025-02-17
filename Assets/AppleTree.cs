using Unity.VisualScripting;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

//Instantiating apples
    public GameObject applePrefab;
    public GameObject stickPrefab;

//AppleTree Move speed
    public float speed = 1f;

//Distance where apple tree turns around
    public float leftAndRightEdge = 10f;

//Chance that Apple Tree change directions
    public float changeDirChance = 1f;

//Seconds between Apple instantiation
    public float appleDropDelay = 1f;

    public float stickDropDelay = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start Dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropStick", 10f);
        
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay);
    }

    void DropStick(){
        GameObject stick = Instantiate<GameObject>(stickPrefab);
        stick.transform.position = transform.position;
        Invoke("DropStick", stickDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


        //Changing direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); //move right
        }
        else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed); //Move left
        }

        
    }

    void FixedUpdate(){
        if(Random.value < changeDirChance){
            speed *= -1; //change direction
        }
    }
}

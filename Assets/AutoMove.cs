using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed ;
    public float minpos,maxpos;
        void Start()
        
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertivcal();
        MoveOnX();
        increaseSpeed();
    }
    void MoveVertivcal(){
            if(Input.GetMouseButton(0)){
                
                    if (getMousePosition().y > minpos && getMousePosition().y < maxpos){
                          print("here");
                         gameObject.transform.position = new Vector3(gameObject.transform.position.x, getMousePosition().y, gameObject.transform.position.z);
                    }
            }

    }


     void  MoveOnX(){
         transform.position += Vector3.right * speed * Time.deltaTime; 
     }
    void increaseSpeed(){
       speed +=0.0001f; 
    }
    Vector2 getMousePosition(){
        
   
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
     
    }

}

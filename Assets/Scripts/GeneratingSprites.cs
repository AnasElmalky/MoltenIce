using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingSprites : MonoBehaviour
{
    #region VARIABLES
    [Header("Refernce Variables")]
    [SerializeField]
    GameObject cameraToDrawAfter;
    [SerializeField]
    GameObject spriteParent;

    [Header("development variables")]
    float spriteHeight;
    #endregion

    #region UNITY CALLBACKS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("here");
        if(collision.gameObject == cameraToDrawAfter)
        {
            print("not here");
            Generate();
        }
    }
    #endregion

    #region PRIVATE METHODS
    private void Generate()
    {
        GameObject currentSprite = Instantiate(this.gameObject, spriteParent.transform);

        currentSprite.transform.position = new Vector3(
            currentSprite.transform.position.x + currentSprite.GetComponent<SpriteRenderer>().size.x * gameObject.transform.localScale.x ,
            currentSprite.transform.position.y,
            currentSprite.transform.position.z
            );
    }
    #endregion
}

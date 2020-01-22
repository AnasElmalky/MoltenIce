using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectExitDestroy : MonoBehaviour
{
    #region VARIABLES
    [Header("Refernce Variables")]
   
   

    [Header("development variables")]
    float spriteHeight;
    #endregion

    #region UNITY CALLBACKS
    private void OnTriggerExit2D(Collider2D collision)
    {   print (collision.gameObject.name);
        if (collision.gameObject.name == "Main Camera")
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}

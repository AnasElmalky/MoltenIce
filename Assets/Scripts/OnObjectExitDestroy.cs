using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnObjectExitDestroy : MonoBehaviour
{
    #region VARIABLES
    [Header("Refernce Variables")]
    [SerializeField]
    GameObject exitedObject;

    [Header("development variables")]
    float spriteHeight;
    #endregion

    #region UNITY CALLBACKS
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == exitedObject)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}

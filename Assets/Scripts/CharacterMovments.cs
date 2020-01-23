using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovments : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    float speed;
    [SerializeField]
    float minYPos, maxYPos;
    #endregion

    #region UNITY CALLBACKS
    private void Update()
    {
        CheckVerticalMovment();
        MoveHorizonatl();
        IncreaseSpeed();
    }
    #endregion

    #region PRiVATE METHODS
    private void CheckVerticalMovment()
    {
        if (Input.GetMouseButton(0))
        {
            if (getMousePosition().y > minYPos && getMousePosition().y < maxYPos)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, getMousePosition().y, gameObject.transform.position.z);
            }
        }
    }
    private void MoveHorizonatl()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void IncreaseSpeed()
    {
        Time.timeScale += .0001f;
    }
    #endregion
}

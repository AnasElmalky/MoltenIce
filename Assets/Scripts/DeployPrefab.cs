using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPrefab : MonoBehaviour
{
    #region VARIABLES

    [Header("REference values")]

    [SerializeField]
    GameObject[] obstecles;
    [SerializeField]
    GameObject obsteclesParent;
    [SerializeField]
    GameObject playerObj;
    [SerializeField]
    float respawnTime =1.0f;

    [Header("Development values")]
    float minYposition = -4.88f;
    float maxYPosition = 0.79f;
    float additionalxValue = 15;
    #endregion

    #region UNITY CALLBACKS
    void Start()
    {
        StartCoroutine(ObtaclesWave());
    }

    #endregion

    #region PRIVATE MEHODS
    private void SpawnObstacel(GameObject obstacleToBeRespawn)
    {
        GameObject newObstacle = Instantiate(obstacleToBeRespawn , obsteclesParent.transform) as GameObject;
        newObstacle.transform.position=new Vector2(playerObj.transform.position.x+ additionalxValue, Random.Range(minYposition, maxYPosition));
    }
    #endregion

    #region CORUOTINES
    IEnumerator ObtaclesWave(){
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            
            SpawnObstacel(obstecles[Random.Range(0,obstecles.Length)]);
        }
    }

    #endregion
}

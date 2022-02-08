using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCircleActiveStatus : MonoBehaviour
{
    //need to get player coordinates and calculate visibility based on that

    GameObject playerObjRef;

    Vector2 playerCoordinates;
    private void Start()
    {
        GameObject playerObjRef = GameObject.Find("playerBall");

        playerCoordinates = playerObjRef.GetComponent<playerMovement>().sendPlayerCoordinates();
    }
    private void Update()
    {
        playerCoordinates = playerObjRef.GetComponent<playerMovement>().sendPlayerCoordinates();
        checkVisibilityAndActivity();
        print(playerCoordinates);
    }

    private void checkVisibilityAndActivity()
    {
        if(this.transform.position.y < playerCoordinates.y)
        {
            this.gameObject.SetActive(false);
        }
    }

}

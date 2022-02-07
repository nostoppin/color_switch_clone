using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerBallCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        managePlayerOnScreen();
    }

    void managePlayerOnScreen()
    {
        if (playerBallCoordinates.position.y > this.transform.position.y)
        {
            this.transform.position = new Vector3(transform.position.x, playerBallCoordinates.position.y, this.transform.position.z);
        }
    }
}

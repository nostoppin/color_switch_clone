using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float enemyCircleRotationSpeed = 0f;

    void Update()
    {
        directionAlternator(); 
        rotateEnemyCircle();
    }

    void rotateEnemyCircle()
    {
        if(directionAlternator() == 0)
        {
            this.transform.Rotate(Vector3.forward * enemyCircleRotationSpeed * Time.deltaTime);
        }
        if(directionAlternator() == 1)
        {
            this.transform.Rotate(Vector3.back * enemyCircleRotationSpeed * Time.deltaTime);
        }
    }

   float directionAlternator()
    {
        float randomval = Mathf.RoundToInt( Random.Range(0, 1) );
        return randomval;
    }
}

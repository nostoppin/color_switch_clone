using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float enemyCircleRotationSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateEnemyCircle();
    }

    void rotateEnemyCircle()
    {
        this.transform.Rotate(Vector3.forward * enemyCircleRotationSpeed * Time.deltaTime);
    }

   
}

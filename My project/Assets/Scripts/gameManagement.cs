using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagement : MonoBehaviour
{
    public GameObject enemyPrefabType1;
    public GameObject enemyPrefabType2;
    public GameObject enemyPrefabType3;
    public GameObject enemyPrefabType4;

    GameObject[] enemyCirclesArray;

    int enemyArrayPopCount = 0;
    int spawnValue = 0;

    public GameObject playerObjRef;

    void Start()
    {
        enemyArrayPopCount = 8;

        enemyCirclesArray = new GameObject[enemyArrayPopCount];
        initAllEnemyTypes();
    }

    // Update is called once per frame
    void Update()
    {
        checkBoundsAndSpawn();
        //checkEnemyCircleInGameView();
        checkEnemyInView();
    }

    private void initAllEnemyTypes()
    {
        for(int i = 0; i < enemyArrayPopCount; i++)
        {
            if (i == 0 || i == 1)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType1, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 2 || i == 3)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType2, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 4 || i == 5)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType3, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 6 || i == 7)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType4, new Vector2(0, 0), Quaternion.identity);
            }
            

            enemyCirclesArray[i].SetActive(false);
        }
    }

    private int getRandomValue(float minVal, float maxVal)
    {
        return Mathf.RoundToInt(Random.Range(minVal, maxVal));
    }

    private void spawnEnemyCircle()
    {
        //print(spawnValue);
        if (!(enemyCirclesArray[spawnValue].activeInHierarchy))
        {
            enemyCirclesArray[spawnValue].transform.position = new Vector2(0, playerObjRef.transform.position.y + 7.5f);
            enemyCirclesArray[spawnValue].SetActive(true);
            enemyCirclesArray[spawnValue].transform.GetChild(0).gameObject.SetActive(true);

            //print(enemyCirclesArray[spawnValue].transform.GetChild(0).gameObject.name);
        }
        spawnValue++;

        if(spawnValue >= 8)
        {
            spawnValue = 0;
        }
    }

    private void checkBoundsAndSpawn()
    {
        //print(playerObjRef.GetComponent<playerMovement>().setSpawnRequest());

        if(playerObjRef.GetComponent<playerMovement>().setSpawnRequest() == true)
        {
            //spawn an enemy 7units above player
            spawnEnemyCircle();
            //choose 1 from enemy array and set active here
            //print("spawned new ");
        }
        //switch off spawn maker
        playerObjRef.GetComponent<playerMovement>().spawnNextEnemy = false;
    }

    private void checkEnemyInView()
    {
        for (int i = 0; i < enemyArrayPopCount; i++)
        {
            if ((enemyCirclesArray[i].activeInHierarchy) && enemyCirclesArray[i].transform.position.y < playerObjRef.transform.position.y - 5f)
            {
                enemyCirclesArray[i].SetActive(false);
            }
        }
    }
}

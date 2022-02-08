using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagement : MonoBehaviour
{
    public GameObject enemyPrefabType1;
    public GameObject enemyPrefabType2;
    public GameObject enemyPrefabType3;
    public GameObject enemyPrefabType4;

    public GameObject colorChangerPrefab;

    GameObject[] enemyCirclesArray;

    int enemyArrayPopCount = 0;
    int spawnValue = 0;

    public GameObject playerObjRef;

    void Start()
    {
        Application.targetFrameRate = 60;

        enemyArrayPopCount = 8;

        enemyCirclesArray = new GameObject[enemyArrayPopCount];
        initAllEnemyTypes();
    }

    void Update()
    {
        checkBoundsAndSpawn();
        spawnColorChanger();
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
        if (!(enemyCirclesArray[spawnValue].activeInHierarchy))
        {
            enemyCirclesArray[spawnValue].transform.position = new Vector2(0, playerObjRef.transform.position.y + 7.5f);
            enemyCirclesArray[spawnValue].SetActive(true);
            enemyCirclesArray[spawnValue].transform.GetChild(0).gameObject.SetActive(true);
        }
        spawnValue++;

        if(spawnValue >= 8)
        {
            spawnValue = 0;
        }
    }

    private void checkBoundsAndSpawn()
    {
        if(playerObjRef.GetComponent<playerMovement>().setSpawnRequest() == true)
        {
            spawnEnemyCircle();
        }
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

    private void spawnColorChanger()
    {
        if(playerObjRef.GetComponent<playerMovement>().colorChangedFlag == true)
        {                                                                                                            //modify 
            Instantiate(colorChangerPrefab, new Vector2(playerObjRef.transform.position.x, playerObjRef.transform.position.y + 14.5f), Quaternion.identity);
        }
        playerObjRef.GetComponent<playerMovement>().colorChangedFlag = false;
    }
}

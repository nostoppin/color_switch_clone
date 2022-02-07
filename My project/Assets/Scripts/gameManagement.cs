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

    void Start()
    {
        enemyArrayPopCount = 4;

        enemyCirclesArray = new GameObject[enemyArrayPopCount];
        initAllEnemyTypes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initAllEnemyTypes()
    {
        for(int i = 0; i < enemyArrayPopCount; i++)
        {
            if (i == 0)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType1, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 1)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType2, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 2)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType3, new Vector2(0, 0), Quaternion.identity);
            }
            if (i == 3)
            {
                enemyCirclesArray[i] = Instantiate(enemyPrefabType4, new Vector2(0, 0), Quaternion.identity);
            }

            enemyCirclesArray[i].SetActive(false);
        }
    }

    private float getRandomValue(float minVal, float maxVal)
    {
        return Mathf.RoundToInt(Random.Range(minVal, maxVal));
    }

    private void spawnEnemyCircle()
    {
        float randomVal = getRandomValue(1f, 4f);

        if(randomVal == 1f)
        {
            enemyCirclesArray[0].SetActive(true);
        }
        if (randomVal == 2f)
        {
            enemyCirclesArray[1].SetActive(true);
        }
        if (randomVal == 3f)
        {
            enemyCirclesArray[2].SetActive(true);
        }
        if (randomVal == 4f)
        {
            enemyCirclesArray[3].SetActive(true);
        }
    }

    //private void check
}

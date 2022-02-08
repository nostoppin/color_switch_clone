using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D playerRigidBody;
        
    SpriteRenderer playerSpriteRenderer;
    
    string playerCurrentColor;

    public Color blueColor;
    public Color yellowColor;
    public Color redColor;
    public Color purpleColor;

    private float ballJumpVel = 4.5f;
    public int playerCurrentScore = 0;

    public bool spawnNextEnemy;
    public bool gameOverFlag;
    public bool colorChangedFlag;

    public AudioClip playerTapSound;
    public AudioClip starCollectedSound;
    public AudioClip colorChangeSound;
    public AudioSource audioSourceBGmusic;
    public AudioSource audioSourcePlayerSound;
    public AudioSource audioSourcePlayerCoinCollected;

    void Start()
    {
        gameOverFlag = false;
        colorChangedFlag = false;
        playerCurrentScore = 0;
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        playerRigidBody.Sleep();
        onSetRandomColor();
    }

    void Update()
    {
        checkPlayerOnScreen();
        playerMovementControls();
        setCurrentScore();
    }

    void playerMovementControls()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            audioSourcePlayerSound.clip = playerTapSound;
            audioSourcePlayerSound.Play();

            playerRigidBody.velocity = new Vector2(0,1) * ballJumpVel;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collectible")
        {
            audioSourcePlayerCoinCollected.clip = starCollectedSound;
            audioSourcePlayerCoinCollected.Play();
            
            collision.gameObject.SetActive(false);
            spawnNextEnemy = true;

            playerCurrentScore += 1;
            
            return;
        }

        if (collision.tag == "colorChanger")
        {
            audioSourcePlayerCoinCollected.clip = colorChangeSound;
            audioSourcePlayerCoinCollected.Play();

            onSetRandomColor();
            Destroy(collision.gameObject);

            colorChangedFlag = true;
            
            return;
        }
        if (collision.tag != playerCurrentColor)
        {
            gameOverFlag = true;
            return;
        }
    }

    public bool setSpawnRequest()
    {
        return spawnNextEnemy;
    }

    public int setCurrentScore()
    {
        return playerCurrentScore;
    }

    private void onSetRandomColor()
    {
        int randomColorValue = Random.Range(0, 3);

        if(randomColorValue == 0)
        {
            playerCurrentColor = "red";
            playerSpriteRenderer.color = redColor;
        }
        else if(randomColorValue == 1)
        {
            playerCurrentColor = "blue";
            playerSpriteRenderer.color = blueColor;
        }
        else if(randomColorValue == 2)
        {
            playerCurrentColor = "yellow";
            playerSpriteRenderer.color = yellowColor;
        }
        else
        {
            playerCurrentColor = "purple";
            playerSpriteRenderer.color = purpleColor;
        }
    }

    public Vector2 sendPlayerCoordinates()
    {
        return this.transform.position;
    }

    private void checkPlayerOnScreen()
    {
        Vector2 cameraCurrentPos = Camera.main.transform.position;

        if(this.transform.position.y < cameraCurrentPos.y - 7.5f)
        {
            gameOverFlag = true;
        }
    }
}

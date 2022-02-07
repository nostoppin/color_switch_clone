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

    private float ballJumpVel = 6.5f;
    public float playerCurrentScore = 0f;

    void Start()
    {
        playerCurrentScore = 0f;
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        onSetRandomColor();
    }

    void Update()
    {
        playerMovementControls();
        setCurrentScore();
        //print(playerCurrentScore);
    }

    void playerMovementControls()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            //print("jump");
            playerRigidBody.velocity = new Vector2(0,1) * ballJumpVel;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collectible")
        {
            collision.gameObject.SetActive(false);
            playerCurrentScore += 1;
            return;
        }

        //print(collision.tag);
        if (collision.tag == "colorChanger")
        {
            onSetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != playerCurrentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //print("die");
        }

        
    }

    public float setCurrentScore()
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

        //print(playerCurrentColor);
    }
}

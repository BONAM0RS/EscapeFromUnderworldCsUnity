using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 3;

    public float moveDistance;
    public float moveSpeed;

    public GameObject moveEffect;
    public GameObject moveSound;
    public GameObject loseSound;

    public Color damagedColor;
    public float damagedColorTimer;
    private float timer = 0;
    private bool isDamaged = false;

    public float gravityPower;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidBody2D;

    private float TopBorder;
    private float BottomBorder;

    private Vector2 targetPos;

    private static PlayerController instance;
    public static PlayerController Instance
    {
        get 
        { 
            if (instance == null) 
            {
                instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return instance; 
        }
    }

    private void Start()
    {
        Cursor.visible = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        TopBorder = moveDistance;
        BottomBorder = -moveDistance;
    }

    private void Update()
    {
        ProcessInputs();

        if (health > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        if (isDamaged == true)
        {
            timer += Time.deltaTime;

            if (timer >= damagedColorTimer)
            {
                ApplyCommonColor();
                timer = 0;
            }
        }
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < TopBorder && health > 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + moveDistance);
            SpawnMoveEffect();
            SpawnMoveSound();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > BottomBorder && health > 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - moveDistance);
            SpawnMoveEffect();
            SpawnMoveSound();
        }

        if (Input.GetKeyDown(KeyCode.R) && health <= 0)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SpawnMoveEffect()
    {
        Instantiate(moveEffect, transform.position, Quaternion.identity);
    }

    private void SpawnMoveSound()
    {
        Instantiate(moveSound, transform.position, Quaternion.identity);
    }

    private void SpawnLoseSound()
    {
        Instantiate(loseSound, transform.position, Quaternion.identity);
    }

    private void ApplyCommonColor()
    {
        spriteRenderer.color = Color.white;
        isDamaged = false;
    }

    private void ApplyDamagedColor()
    {
        spriteRenderer.color = damagedColor;
        isDamaged = true;
    }

    private void DisablePlayer()
    {
        SpawnLoseSound();

        // If we want to fall a player
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidBody2D.gravityScale = gravityPower;

        // If we want to hide a player
        //spriteRenderer.enabled = false;
        //boxCollider2D.enabled = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void DamagePlayer(int damage)
    {
        if (health > 0)
        {
            health -= damage;

            ApplyDamagedColor();
            ControllerUI.Instance.RemoveHeart(health);

            if (health <= 0)
            {
                DisablePlayer();
                ControllerUI.Instance.ShowGameOver();
            }
        }
    }
}

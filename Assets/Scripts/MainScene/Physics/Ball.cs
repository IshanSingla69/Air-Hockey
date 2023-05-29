using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour, IResettable
{
    public float speed = 5f;
    public float maxSpeed = 10f;

    public AudioManager audioManager;
    private Rigidbody2D rb;
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    

    Vector2 startPosition;

    public static bool WasGoal { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        WasGoal = false;
        startPosition = rb.position;
        UIManager.Instance.ResetableGameObjects.Add(this);
        //Launch();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!WasGoal)
        {
            if (collision.CompareTag("Player2Goal"))
            {
                gameManager.Increment(GameManager.Score.Player1Score);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
            else if(collision.CompareTag("Player1Goal"))
            {
                gameManager.Increment(GameManager.Score.player2Score);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ExternalBoundaries"))
        {
            ResetPosition();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        /*rb.position = Mathf.Clamp(rb.position.x, -2.5f, 2.5f) == rb.position.x ? rb.position : new Vector2(Mathf.Clamp(rb.position.x, -2.5f, 2.5f), rb.position.y);
        rb.position = Mathf.Clamp(rb.position.y, -5f, 5f) == rb.position.y ? rb.position : new Vector2(rb.position.x, Mathf.Clamp(rb.position.y, -5f, 5f));*/
    }

    public void Launch()
    {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private IEnumerator ResetPuck( bool didAiScore)
    {
        rb.position = startPosition;
        rb.velocity = Vector2.zero;
        spriteRenderer.enabled = false;
        rb.position = new Vector2(0, didAiScore ? -1f : 1f);
        yield return new WaitForSeconds(1);
        WasGoal = false;
        spriteRenderer.enabled = true;
    }

    public void ResetPosition()
    {
        rb.position = startPosition;
        rb.velocity = Vector2.zero;
    }
    
}

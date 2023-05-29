using UnityEngine;

public class PlayerMovement : MonoBehaviour, IResettable
{
    
    Vector2 startPosition;
    Boundary playerBoundary;

    private Rigidbody2D rb;
    public Transform boundaryHolder;
    public Collider2D PlayerCollider { get; private set; }
    public PlayerController Controller;

    public int? LockedFingerID { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        rb.isKinematic = true;

        playerBoundary = new Boundary(boundaryHolder.GetChild(0).position.y,
                                     boundaryHolder.GetChild(1).position.y,
                                     boundaryHolder.GetChild(2).position.x,
                                     boundaryHolder.GetChild(3).position.x);
        startPosition = rb.position;

    }

    private void OnEnable()
    {
        Controller.Players.Add(this); 
        UIManager.Instance.ResetableGameObjects.Add(this);
    }

    private void OnDisable()
    {
        Controller?.Players.Remove(this);
        UIManager.Instance.ResetableGameObjects.Remove(this);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = startPosition;
    }

    public void MoveToPosition(Vector2 pos)
    {
        Vector2 clampedMoudePos = new Vector2(Mathf.Clamp(pos.x, playerBoundary.Left, playerBoundary.Right),
                                                      Mathf.Clamp(pos.y, playerBoundary.Down, playerBoundary.Up));
        rb.MovePosition(clampedMoudePos);
    }
}
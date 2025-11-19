using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField, Range(0.1f, 10f)] private float speed = 1f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.linearVelocity = Vector2.right * speed;
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = rigidbody2D.linearVelocity.normalized * speed;
    }
}

using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    Vector2 initialPosition;

    [SerializeField, Range(0.1f, 10f)] private float speed = 10f;
    [SerializeField, Range(10f, 100f)] private float maxSpeed = 20f;

    private const float MAX_ANGLE = 30f;    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        Reset();
    }

    public void Reset()
    {
        transform.position = initialPosition;
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        rigidbody2D.linearVelocity = new Vector2(x, y) * speed;
    }

    public void FixedUpdate()
    {
        Vector2 v = rigidbody2D.linearVelocity;

        if (v.magnitude < speed)
        {
            v = v.normalized * speed;
        }

        float angle = Vector2.Angle(v, Vector2.right);

        if (angle > 90f) angle = 180f - angle;

        if (angle > MAX_ANGLE)
        {
            float newAngle = Mathf.Sign(v.y) * MAX_ANGLE;
            float rad = newAngle * Mathf.Deg2Rad;

            float newX = Mathf.Cos(rad) * v.magnitude * Mathf.Sign(v.x);
            float newY = Mathf.Sin(rad) * v.magnitude;

            v = new Vector2(newX, newY);
        }

        rigidbody2D.linearVelocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Vector2 v = rigidbody2D.linearVelocity;
            v *= 1.05f;
            v = Vector2.ClampMagnitude(v, maxSpeed);
            rigidbody2D.linearVelocity = v;
        }
        else if (collision.gameObject.name.Contains("Goal01"))
        {
            GameMannager.Instance.PointScore(false);
        }
        else if (collision.gameObject.name.Contains("Goal02"))
        {
            GameMannager.Instance.PointScore(true);
        }
    }
}

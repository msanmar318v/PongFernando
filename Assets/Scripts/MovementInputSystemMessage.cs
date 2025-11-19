using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementInputSystemMessage : MonoBehaviour
{

    [SerializeField, Range(1f, 100f)] private float speed = 5f;

    private float verticalInput = 0f;

    [SerializeField, Range(0.5f, 10f)] private float acceleration = 1f;

    private float verticalAcceleration = 0f;

    private Vector2 inputMovement;

    private enum MoveDirection
    {
        Idle = 0,
        Up = 1,
        Down = -1
    }

    private MoveDirection moveDirection;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        moveDirection = MoveDirection.Idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue context)
    {
        this.inputMovement = context.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        moveDirection = inputMovement.y > 0 ? MoveDirection.Up : inputMovement.y < 0 ? MoveDirection.Down : MoveDirection.Idle;
        rigidbody2D.linearVelocity = (float)moveDirection * speed * Vector2.up;
    }

    void Update()
    {
        //verticalInput = Mathf.Clamp(inputMovement.y, -1f, 1f);

        //if (verticalInput > 0f)
        //{
        //    if (moveDirection != MoveDirection.Up)
        //    {
        //        verticalAcceleration = 0f;
        //        moveDirection = MoveDirection.Up;
        //    }

        //    if (verticalAcceleration < 1f)
        //    {
        //        verticalAcceleration += acceleration * Time.deltaTime;
        //    }
        //}
        //else if (verticalInput < 0f)
        //{
        //    if (moveDirection != MoveDirection.Down)
        //    {
        //        verticalAcceleration = 0f;
        //        moveDirection = MoveDirection.Down;
        //    }

        //    if (verticalAcceleration > -1f)
        //    {
        //        verticalAcceleration -= acceleration * Time.deltaTime;
        //    }
        //}
        //else
        //{
        //    if (verticalAcceleration > 0f && moveDirection != MoveDirection.Idle)
        //    {
        //        verticalAcceleration -= acceleration * Time.deltaTime;

        //        if (verticalAcceleration < 0f)
        //        {
        //            verticalAcceleration = 0f;
        //        }
        //    }
        //    else if (verticalAcceleration < 0f && moveDirection != MoveDirection.Idle)
        //    {
        //        verticalAcceleration += acceleration * Time.deltaTime;
        //        if (verticalAcceleration > 0f)
        //        {
        //            verticalAcceleration = 0f;
        //        }
        //    }

        //    if (verticalAcceleration == 0f)
        //    {
        //        moveDirection = MoveDirection.Idle;
        //    }
        //}

        //transform.Translate(Vector2.up * (Mathf.Clamp01(Mathf.Abs(verticalAcceleration)) * verticalInput * speed * Time.deltaTime));
    }
}
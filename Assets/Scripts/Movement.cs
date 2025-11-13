using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool useKeyInput = true;

    [SerializeField, Range(1f, 100f)] private float speed = 5f;

    private float verticalInput = 0f;

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (useKeyInput)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                verticalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                verticalInput = -1f;
            }
            else
            {
                verticalInput = 0f;
            }
        }
        else
        {
            verticalInput = Input.GetAxis("Vertical");
        }

        transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);
        Debug.Log("Vertical Input: " + verticalInput);
    }
}
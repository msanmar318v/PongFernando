using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovementInputSystem : MonoBehaviour
{

    [SerializeField, Range(1f, 100f)] private float speed = 5f;

    private float verticalInput = 0f;

    [SerializeField, Range(0.5f, 10f)] private float acceleration = 5f;

    private float horizontalInputSliderValue = 0f;

    // Ui Controll reference
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textValue;

    private enum MoveDirection
    {
        Idle,
        Up,
        Down
    }

    private MoveDirection moveDirection;
    private Image colorSlider;
    private InputAction moveAction;

    private void Start()
    {
        moveDirection = MoveDirection.Idle;
        colorSlider = slider.fillRect.GetComponent<Image>();
        moveAction = InputSystem.actions.FindAction("Move");

        if (moveAction == null)
        {
            Debug.LogError("No se encontró la acción 'Move' en el Input System. Comprueba el nombre exacto.");
        }
    }

    void Update()
    {
        if (moveAction == null) return;

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        verticalInput = Mathf.Clamp(moveValue.y, -1f, 1f);

        if (verticalInput > 0f)
        {
            if (moveDirection != MoveDirection.Up)
            {
                horizontalInputSliderValue = 0f;
                moveDirection = MoveDirection.Up;
            }

            if (horizontalInputSliderValue < 1f)
            {
                horizontalInputSliderValue += acceleration * Time.deltaTime;
            }
        }
        else if (verticalInput < 0f)
        {
            if (moveDirection != MoveDirection.Down)
            {
                horizontalInputSliderValue = 0f;
                moveDirection = MoveDirection.Down;
            }

            if (horizontalInputSliderValue > -1f)
            {
                horizontalInputSliderValue -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (horizontalInputSliderValue > 0f && moveDirection != MoveDirection.Idle)
            {
                horizontalInputSliderValue -= acceleration * Time.deltaTime;

                if (horizontalInputSliderValue < 0f)
                {
                    horizontalInputSliderValue = 0f;
                }
            }
            else if (horizontalInputSliderValue < 0f && moveDirection != MoveDirection.Idle)
            {
                horizontalInputSliderValue += acceleration * Time.deltaTime;
                if (horizontalInputSliderValue > 0f)
                {
                    horizontalInputSliderValue = 0f;
                }
            }

            if (horizontalInputSliderValue == 0f)
            {
                moveDirection = MoveDirection.Idle;
            }
        }

        slider.value = Mathf.Clamp01(Mathf.Abs(horizontalInputSliderValue));

        if (slider.value == 0f)
        {
            colorSlider.color = Color.white;
        }
        else if (slider.value < 0.25f)
        {
            colorSlider.color = Color.green;
        }
        else if (slider.value < 0.5f)
        {
            colorSlider.color = Color.yellow;
        }
        else if (slider.value < 0.75f)
        {
            colorSlider.color = new Color(1f, 0.64f, 0f);
        }
        else
        {
            colorSlider.color = Color.red;
        }

        float displayValue = slider.value * 100f;
        textValue.text = displayValue.ToString("F0") + "%";

        transform.Translate(Vector2.up * (slider.value * verticalInput * speed * Time.deltaTime));
    }
}


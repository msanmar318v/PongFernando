using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovementAC : MonoBehaviour
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

    private void Start()
    {
        moveDirection = MoveDirection.Idle;
        colorSlider = slider.fillRect.GetComponent<Image>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (moveDirection != MoveDirection.Up)
            {
                horizontalInputSliderValue = 0f;
                moveDirection = MoveDirection.Up;
            }
            verticalInput = 1f;
            if (horizontalInputSliderValue < 1f)
            {
                horizontalInputSliderValue += acceleration * Time.deltaTime;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            if (moveDirection != MoveDirection.Down)
            {
                horizontalInputSliderValue = 0f;
                moveDirection = MoveDirection.Down;
            }
            verticalInput = -1f;
            if (horizontalInputSliderValue > -1f)
            {
                horizontalInputSliderValue -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            verticalInput = 0f;
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
        float compareValue = slider.value;
        if (compareValue < 0f)
        {
            compareValue = Mathf.Abs(compareValue);
        }

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
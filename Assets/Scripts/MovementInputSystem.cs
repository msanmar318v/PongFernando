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
    }

    void Update()
    {
        
    }
}

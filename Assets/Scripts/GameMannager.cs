using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameMannager : MonoBehaviour
{
    public static GameMannager Instance { get; private set; }

    private int p01Points = 0;
    private int p02Points = 0;

    [SerializeField] private TextMeshProUGUI p01Score;
    [SerializeField] private TextMeshProUGUI p02Score;

    // Objetos del juego
    [SerializeField] private Ball ball;
    [SerializeField] private MovementInputSystemMessage01 player01;
    [SerializeField] private MovementInputSystemMessage player02;

    private bool paused = false;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Reset();
        panel.SetActive(false);
    }

    private void Reset()
    {
        p01Points = 0;
        p02Points = 0;
        p01Score.text = "00";
        p02Score.text = "00";
        ball.Reset();
        player01.Reset();
        player02.Reset();
    }

    public void Reset(CallbackContext context)
    {
        if (context.performed)
        {
            Reset();
        }
    }

    public void ResetRound()
    {
        ball.Reset();
        player01.Reset();
        player02.Reset();
    }

    public void PointScore(bool playerLeftScore)
    {
       if (playerLeftScore)
        {
            p01Points++;
            p01Score.text = p01Points.ToString("00");
        }
        else
        {
            p02Points++;
            p02Score.text = p02Points.ToString("00");
        }
        ball.Reset();
        player01.Reset();
        player02.Reset();
    }

    private void Pause()
    {
        paused = !paused;
        panel.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;
    }

    public void Onpause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Pause();
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Gun gun;
    [HideInInspector] public string nombreDelObjeto;

    SpriteRenderer spriteRenderer;

    [Header("Movement")]
    [SerializeField, Range(0f, 100f)] private float speedX;
    [SerializeField, Range(0f, 100f)]private float speedY;

    [Space(25)]
    [SerializeField, Range(0, 100), Tooltip("Indica la salud del jugador del 0 al 100")] private int life;

    [SerializeField, TextArea(minLines: 3, maxLines: 7)] private string description;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Mi pistola es " + gun.name);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

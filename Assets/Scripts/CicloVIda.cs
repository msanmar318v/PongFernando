using UnityEngine;

public class CicloVIda : MonoBehaviour
{
    static CicloVIda()
    {
        Debug.Log("Ciclo Vida: Static CicloVida()");
    }

    public CicloVIda()
    {
        Debug.Log("Ciclo Vida: CicloVida()");
    }

    void Awake()
    {
        Debug.Log("Ciclo Vida: Awake()");
    }

    void OnEnable()
    {
        Debug.Log("Ciclo Vida: OnEnable()");
    }

    private void Reset()
    {
        Debug.Log("Ciclo Vida: Reset()");
    }

    void Start()
    {
        Debug.Log("Ciclo Vida: Start()");
    }

    void FixedUpdate()
    {
        Debug.Log("Ciclo Vida: FixedUpdate()");

    }

    void Update()
    {
        Debug.Log("Ciclo Vida: Update()");
    }

    void LateUpdate()
    {
        Debug.Log("Ciclo Vida: LateUpdate()");
    }

    void OnApplicationPause(bool pause)
    {
        Debug.Log("Ciclo Vida: OnApplicationPause()");
    }

    void OnApplicationQuit()
    {
        Debug.Log("Ciclo Vida: OnApplicationQuit()");
    }
    
    void OnDisable()
    {
        Debug.Log("Ciclo Vida: OnDisable()");
    }

    void OnDestroy()
    {
        Debug.Log("Ciclo Vida: OnDestroy()");
    }
}

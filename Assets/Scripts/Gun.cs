using UnityEngine;

public class Gun : MonoBehaviour
{
    public string name;
    public int bullets;

    public Gun(string name, int bullets)
    {
        this.name = name;
        this.bullets = bullets;
    }

    public Gun()
    {
        this.name = "Default Gun";
        this.bullets = 10;
    }
}

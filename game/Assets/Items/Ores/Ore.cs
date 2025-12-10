using UnityEngine;

public class Ore : MonoBehaviour
{
    public int hp = 3;

    public void Hit()
    {
        hp--;

        if (hp <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        Destroy(gameObject);
    }
}

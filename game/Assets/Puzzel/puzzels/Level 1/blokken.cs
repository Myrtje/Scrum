using UnityEngine;

public class blokken : MonoBehaviour
{
    private GameObject OreCar;
    public GameObject kar1, kar2, kar3, kar4, kar5, kar6, kar7, kar8;
    
    void Start()
    {
        OreCar = GameObject.Find("kar ore").GetComponent<GameObject>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "kar ore")
        {
            
        }
    }
}
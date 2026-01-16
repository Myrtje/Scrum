using UnityEngine;

public class ForgePlace : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //loadscene puzzle
        }
    }
}

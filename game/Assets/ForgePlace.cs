using UnityEngine;
using UnityEngine.SceneManagement;

public class ForgePlace : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("puzzel1");
            SceneManager.LoadScene("puzzel1");
        }
    }
}

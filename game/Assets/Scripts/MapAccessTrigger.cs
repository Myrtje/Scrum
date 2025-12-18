using UnityEngine;

public class MapAccessTrigger : MonoBehaviour
{
    private MapManager mapManager;

    void Start() => mapManager = FindObjectOfType<MapManager>();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) mapManager?.SetMapAccess(true);   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mapManager?.SetMapAccess(false);
            mapManager?.CloseMap();
        }
    }
}
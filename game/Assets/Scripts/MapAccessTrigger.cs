using UnityEngine;

public class MapAccessTrigger : MonoBehaviour
{
    private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        if (mapManager == null)
        {
            Debug.LogError("Geen mapManager");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && mapManager != null)
        {
            mapManager.SetMapAccess(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && mapManager != null)
        {
            mapManager.SetMapAccess(false);
            mapManager.CloseMap();
        }
    }
}
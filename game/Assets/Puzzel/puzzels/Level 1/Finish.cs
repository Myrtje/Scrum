using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    private bool levelGelukt = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!levelGelukt && other.gameObject.name == "kar ore")
        {
            levelGelukt = true;
            Debug.Log("LEVEL GELUKT!");
            
            // TODO: pauzeer tijd, toon panel, laad scene, etc.
            // Time.timeScale = 0;
            // winPanel.SetActive(true);
            SceneManager.LoadScene("World");
        }
    }
}
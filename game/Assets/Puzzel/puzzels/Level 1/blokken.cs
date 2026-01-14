using UnityEngine;

public class Blokken : MonoBehaviour
{
    private Rigidbody2D selectedRb;
    private Vector2 offset;

    private Collider2D karOreCollider;
    private bool levelGelukt = false;

    void Start()
    {
        GameObject karOre = GameObject.Find("kar ore");
        if (karOre != null)
            karOreCollider = karOre.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (levelGelukt) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null) return;

            selectedRb = hit.collider.GetComponent<Rigidbody2D>();
            if (selectedRb == null) return;

            offset = selectedRb.position - mousePos;

            selectedRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (hit.collider.CompareTag("Horizontal"))
                selectedRb.constraints |= RigidbodyConstraints2D.FreezePositionY;
            else if (hit.collider.CompareTag("Vertical"))
                selectedRb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        }

        if (Input.GetMouseButton(0) && selectedRb != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedRb.MovePosition(mousePos + offset);
        }

        if (Input.GetMouseButtonUp(0) && selectedRb != null)
        {
            if (selectedRb.CompareTag("Horizontal"))
                selectedRb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            else if (selectedRb.CompareTag("Vertical"))
                selectedRb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            else
                selectedRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            selectedRb = null;
        }

        CheckFinish();
    }

    void CheckFinish()
    {
        if (karOreCollider == null) return;

        Collider2D finish = Physics2D.OverlapPoint(
            karOreCollider.bounds.center,
            LayerMask.GetMask("Finish")
        );

        if (finish != null && finish.CompareTag("Finish"))
        {
            Debug.Log("LEVEL GELUKT!");
            LevelGelukt();
        }
    }

    void LevelGelukt()
    {
        levelGelukt = true;
        

        // Hier later:
        // Time.timeScale = 0;
        // winPanel.SetActive(true);
        // SceneManager.LoadScene(...)
    }
}
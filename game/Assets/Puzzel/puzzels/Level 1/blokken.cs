using UnityEngine;

public class BlokkenManager : MonoBehaviour
{
    private Rigidbody2D selectedRb;
    private Vector2 offset;

    void Update()
    {
        HandleDrag();
    }

    private void HandleDrag()
    {
        // Muisknop ingedrukt
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null) return;

            selectedRb = hit.collider.GetComponent<Rigidbody2D>();
            if (selectedRb == null) return;

            offset = selectedRb.position - mousePos;

            // Stel beperkingen in
            selectedRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (hit.collider.CompareTag("Horizontal"))
                selectedRb.constraints |= RigidbodyConstraints2D.FreezePositionY;
            else if (hit.collider.CompareTag("Vertical"))
                selectedRb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        }

        // Blok volgen
        if (Input.GetMouseButton(0) && selectedRb != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedRb.MovePosition(mousePos + offset);
        }

        // Loslaten
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
    }
}
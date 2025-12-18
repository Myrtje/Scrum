using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [Header("Camera's")]
    public Camera mainCamera;
    public Camera mapCamera;
    
    [Header("Speler Componenten")]
    public MonoBehaviour playerMovementScript;
    
    [Header("UI Componenten")]
    public Canvas Hud;

    private bool isMapOpen = false;
    private bool canAccessMap = false;

    void Start() => mapCamera.enabled = false;

    public void SetMapAccess(bool access) => canAccessMap = access;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMapOpen) CloseMap();
            else if (canAccessMap) OpenMap(); 
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && isMapOpen) CloseMap();
    }

    public void OpenMap()
    {
        if (mapCamera == null || mainCamera == null) return;
        
        mainCamera.enabled = false;
        mapCamera.enabled = true;
        
        if (playerMovementScript != null) playerMovementScript.enabled = false;
        if (Hud != null) Hud.enabled = false;
        
        isMapOpen = true;
    }

    public void CloseMap()
    {
        if (mapCamera == null || mainCamera == null) return;

        mapCamera.enabled = false;
        mainCamera.enabled = true;

        if (playerMovementScript != null) playerMovementScript.enabled = true;
        if (Hud != null) 
        {
            Hud.enabled = true;
            isMapOpen = false;
        }
    }
}
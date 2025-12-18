using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [Header("Cameras & UI")]
    public Camera mainCamera, mapCamera;
    public Canvas Hud;

    [Header("Player")]
    public MonoBehaviour playerMovementScript;

    private bool isMapOpen, canAccessMap;

    void Start() => mapCamera.enabled = false;

    public void SetMapAccess(bool access) => canAccessMap = access;

    void Update()
    {
        bool inputExit = Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape);

        if (isMapOpen && inputExit) CloseMap();
        else if (!isMapOpen && canAccessMap && Input.GetKeyDown(KeyCode.M)) OpenMap();
    }

    public void OpenMap() => SetMapState(true);
    public void CloseMap() => SetMapState(false);

    private void SetMapState(bool open)
    {
    isMapOpen = open;
    if (mainCamera) mainCamera.enabled = !open;
    if (mapCamera) mapCamera.enabled = open;
    if (playerMovementScript) playerMovementScript.enabled = !open;
    if (Hud) Hud.enabled = !open;
    }
}
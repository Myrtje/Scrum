using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(0, 0, -10);
    [SerializeField] private float smoothTime = 0.25f, normalZoom = 5f;
    
    private Vector3 velocity = Vector3.zero;

    void Start() => GetComponent<Camera>().orthographicSize = normalZoom;

    void LateUpdate()
    {
        if (target) transform.position = Vector3.SmoothDamp(
            transform.position, target.position + offset, ref velocity, smoothTime);
    }
}
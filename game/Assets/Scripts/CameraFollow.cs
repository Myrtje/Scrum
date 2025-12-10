using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, -10);

    [SerializeField]
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float normalZoom = 5f;


    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = normalZoom;
    }

    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );

        // float targetZoom = isZoomOutPressed ? zoomedOut : normalZoom;
        // cam.orthographicSize = Mathf.Lerp(
        //     cam.orthographicSize,
        //     targetZoom,
        //     Time.deltaTime * zoomSpeed
        // );
    }
}
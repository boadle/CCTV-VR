using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float MinZoom = 0.5f;

    public float MaxZoom = 3f;

    [Range(-90, 90)]
    public float InitialVerticalAngle = 0f;

    [Range(-360, 360)]
    public float InitialHorizontalAngle = 0f;

    [Range(-90, 90)]
    public float MinVerticalAngle = -45f;

    [Range(-90, 90)]
    public float MaxVerticalAngle = 45f;

    [Range(-360, 360)]
    public float MinHorizontalAngle = -360f;

    [Range(-360, 360)]
    public float MaxHorizontalAngle = 360f;

    protected Camera camera;

    protected float initialFov;

    protected float zoom = 1f;

    protected float currentVerticalAngle = 0f;

    protected float currentHorizontalAngle = 0f;

    void Awake()
    {
        camera = GetComponentInChildren<Camera>();

        if (camera == null)
        {
            Debug.LogError("SecurityCamera: No Camera found" + name);
        }

        initialFov = camera.fieldOfView;

        if (MinVerticalAngle > MaxVerticalAngle)
        {
            MinVerticalAngle = MaxVerticalAngle;
        }
        if (MinHorizontalAngle > MaxHorizontalAngle)
        {
            MinHorizontalAngle = MaxHorizontalAngle;
        }

        InitialVerticalAngle = Mathf.Clamp(InitialVerticalAngle, MinVerticalAngle, MaxVerticalAngle);
        InitialHorizontalAngle = Mathf.Clamp(InitialHorizontalAngle, MinHorizontalAngle, MaxHorizontalAngle);

        currentVerticalAngle = InitialVerticalAngle;
        currentHorizontalAngle = InitialHorizontalAngle;
        transform.eulerAngles = new Vector3(currentVerticalAngle, currentHorizontalAngle, 0);
    }

    public void RotateLeft(float amount)
    {
        RotateHorizontal(-Mathf.Abs(amount));
    }

    public void RotateRight(float amount)
    {
        RotateHorizontal(Mathf.Abs(amount));
    }

    public void RotateDown(float amount)
    {
        RotateVertical(-Mathf.Abs(amount));
    }

    public void RotateUp(float amount)
    {
        RotateVertical(Mathf.Abs(amount));
    }

    public void RotateVertical(float amount)
    {
        currentVerticalAngle -= amount;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, MinVerticalAngle, MaxVerticalAngle);
        transform.eulerAngles = new Vector3(currentVerticalAngle, currentHorizontalAngle, 0);
    }

    public void RotateHorizontal(float amount)
    {
        currentHorizontalAngle += amount;
        currentHorizontalAngle = Mathf.Clamp(currentHorizontalAngle, MinHorizontalAngle, MaxHorizontalAngle);
        transform.eulerAngles = new Vector3(currentVerticalAngle, currentHorizontalAngle, 0);
    }

    public void ZoomIn(float amount)
    {
        Zoom(Mathf.Abs(amount));
    }

    public void ZoomOut(float amount)
    {
        Zoom(-Mathf.Abs(amount));
    }

    public void Zoom(float amount)
    {
        zoom = Mathf.Clamp(zoom + amount, MinZoom, MaxZoom);
        camera.fieldOfView = initialFov / zoom;
    }

    public void ResetZoom()
    {
        camera.fieldOfView = initialFov;
    }
}

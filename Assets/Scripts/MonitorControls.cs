using UnityEngine;

public class MonitorControls : MonoBehaviour
{
    public GameObject MainCamera;

    public SecurityCameraControls SecurityCameraControls;

    public Monitor selectedMonitor;

    protected Ray ray;

    protected RaycastHit hit;

    void Awake()
    {
        if (MainCamera == null)
        {
            Debug.LogError("MonitorManager: No MainCamera attached");
        }
        if (SecurityCameraControls == null)
        {
            Debug.LogError("MonitorManager: No SecurityCameraControls attached");
        }

        ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
    }

    void Start()
    {
        if (selectedMonitor != null)
        {
            selectedMonitor.Select();
            SecurityCameraControls.SelectCamera(selectedMonitor.SecurityCamera);
        }
    }

    void Update()
    {
        Monitor monitorHit = null;

        // update ray
        ray.origin = MainCamera.transform.position;
        ray.direction = MainCamera.transform.forward;

        if (Physics.Raycast(ray, out hit))
        {
            // check if monitor screen is hit
            Transform objectHit = hit.transform.parent;
            if (objectHit)
            {
                monitorHit = objectHit.GetComponent<Monitor>();
            }
        }


        if (monitorHit != null)
        {
            if (selectedMonitor != monitorHit)
            {
                if (selectedMonitor != null)
                {
                    selectedMonitor.Deselect();
                    SecurityCameraControls.DeselectCamera(selectedMonitor.SecurityCamera);
                }
                monitorHit.Select();
                selectedMonitor = monitorHit;
                SecurityCameraControls.SelectCamera(selectedMonitor.SecurityCamera);
            }
        }
    }
}

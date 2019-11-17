using UnityEngine;

public class SecurityCameraControls : MonoBehaviour
{
    public float ZoomSpeed = 1f;

    public float TurnSpeed = 1f;

    protected SecurityCamera selectedCamera = null;

    public void SelectCamera(SecurityCamera camera)
    {
        selectedCamera = camera;
    }

    public void DeselectCamera(SecurityCamera camera)
    {
        selectedCamera = null;
    }

    void Update()
    {
        if (!selectedCamera)
        {
            return;
        }

        float leftAxisX = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        float leftAxisY = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");
        float rightAxisY = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");

        // process vertical rotation
        float rotateAmount = TurnSpeed * Time.deltaTime;

        if (leftAxisY != 0)
        {
            // rotate vertically with left stick
            selectedCamera.RotateVertical(rotateAmount * leftAxisY);
        } else
        {
            // rotate vertically with keyboard
            if (Input.GetKey(KeyCode.DownArrow))
            {
                selectedCamera.RotateDown(rotateAmount);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                selectedCamera.RotateUp(rotateAmount);
            }
        }

        // process horizontal rotation
        if (leftAxisX != 0)
        {
            // rotate horizontally with left stick
            selectedCamera.RotateHorizontal(rotateAmount * leftAxisX);
        }
        else
        {
            // rotate horizontally with keyboard
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                selectedCamera.RotateLeft(rotateAmount);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                selectedCamera.RotateRight(rotateAmount);
            }
        }

        // process zoom
        float zoomAmount = ZoomSpeed * Time.deltaTime;

        if (rightAxisY != 0)
        {
            // zoom with right stick
            selectedCamera.Zoom(zoomAmount * rightAxisY);
        } else
        {
            // zoom with keyboard
            if (Input.GetKey(KeyCode.Z))
            {
                selectedCamera.ZoomIn(zoomAmount);
            }

            if (Input.GetKey(KeyCode.X))
            {
                selectedCamera.ZoomOut(zoomAmount);
            }
        }
    }
}

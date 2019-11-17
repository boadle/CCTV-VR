using UnityEngine;

public class Monitor : MonoBehaviour
{
    public SecurityCamera SecurityCamera;

    protected bool isSelected;

    protected Color initialColor;

    protected float initialIntensity;

    protected Light light;

    void Awake()
    {
        light = GetComponentInChildren<Light>();
        initialColor = light.color;
        initialIntensity = light.intensity;
    }

    public void Select()
    {
        isSelected = true;
        light.color = Color.red;
        light.intensity = 0.8f;
    }

    public void Deselect()
    {
        isSelected = false;
        light.color = initialColor;
        light.intensity = initialIntensity;
    }

    public bool IsSelected()
    {
        return isSelected;
    }
}

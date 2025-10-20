using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Header("Rotation Speed (degrees per second)")]
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Y-axis rotation by default

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

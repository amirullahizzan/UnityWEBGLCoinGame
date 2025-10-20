using UnityEngine;

public class JsReceiver : MonoBehaviour
{
    public Canvas canvas;          // assign your Canvas
    public RectTransform fingerUI; // assign a UI Image (cursor) in Inspector
    public Camera cam; //for 3d
    public GameObject objectToMove3D;

    public void ReceiveVector3(string json)
    {
        Vector3 v = JsonUtility.FromJson<Vector3>(json);
        //Debug.Log($"Normalized from JS: {v.x}, {v.y}, {v.z}");

        // Convert normalized (0–1) → screen coordinates
        Vector2 screenPos = new Vector2(
            v.x * Screen.width,
            (1f - v.y) * Screen.height // flip Y (JS has top=0, Unity has bottom=0)
        );

        // Convert screen → canvas local coordinates
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            screenPos,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out Vector2 localPos
        );

        fingerUI.anchoredPosition = localPos;

        Move3DObjectX(v);
    }

    // public void Move3DObject(string json)
    // {
    //     Vector3 v = JsonUtility.FromJson<Vector3>(json);

    //     // MediaPipe Y is top=0, Unity viewport Y is bottom=0 → flip Y
    //     float flippedY = 1f - v.y;

    //     // Choose how far in front of the camera to place the object
    //     float depth = 2.0f; // the camera's z doesnt work for some reason so we skip that.

    //     // Convert viewport → world space
    //     Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(v.x, flippedY, objectToMove3D.transform.position.z));
    //     Debug.Log($"Viewport from JS: {worldPos}");

    //     objectToMove3D.transform.position = worldPos;
    // }
    
 private void Move3DObjectX(Vector3 v)
{
    // v.x is normalized (0–1)
    float normX = v.x;

    // Map normalized X into world space range
    float worldX = Mathf.Lerp(-10f, 10f, normX); // adjust -5,5 to fit your scene

    // Keep Y and Z unchanged
    Vector3 currentPos = objectToMove3D.transform.position;
    Vector3 newPos = new Vector3(worldX, currentPos.y, currentPos.z);

    objectToMove3D.transform.position = newPos;
}
}

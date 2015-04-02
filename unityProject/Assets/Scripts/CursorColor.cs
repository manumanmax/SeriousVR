using UnityEngine;

[RequireComponent(typeof(RayCast))]
public class CursorColor : MonoBehaviour
{
    private CameraGrabber cameraScript;

    public bool dragOk = false;


    private void Awake()
    {
        cameraScript = GetComponent<CameraGrabber>();
    }

    void OnMouseDown()
    {
        if (cameraScript.display)
        {
            print("#cursorColor : draging is possible");
            dragOk = true;
        }
    }

    void OnMouseUp()
    {
        dragOk = false;

    }




}

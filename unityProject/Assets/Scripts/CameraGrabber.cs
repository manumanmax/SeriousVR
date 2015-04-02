using UnityEngine;
using System.Collections;

public class CameraGrabber : MonoBehaviour
{
    public GameObject hitObject = null;
    private Ray ray;
    private RaycastHit hit;
    private static Texture2D t;
    public static int size = 6;
    public Vector2 cursorPos;

    public bool display = false;
    public bool dragOk = false;

    private GameObject objectDragged = null;


    // Use this for initialization
    void Start()
    {

    }
    private void Awake()
    {
        t = new Texture2D(size, size, TextureFormat.RGB24, true);
        t.name = "Procedural Texture";
        FillTexture(Color.green);
        cursorPos = new Vector2(Screen.width / 2, Screen.height / 2);
    }



    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(new Vector3(cursorPos.x,cursorPos.y, 0.0f));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        Debug.Log(ray);

        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.transform.gameObject;
            if (hitObject.tag.Equals("grabbable"))
            {
                display = true;
                if (Input.GetMouseButtonDown(0))
                {
                    objectDragged = hitObject;
                    dragOk = true;
                }
            }
            else
            {
                display = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragOk = false;
            objectDragged = null;
        }


        if (dragOk)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(cursorPos.x, cursorPos.y, hit.distance));
            worldPos = new Vector3(worldPos.x, worldPos.y, objectDragged.transform.position.z);
            objectDragged.rigidbody.MovePosition(worldPos);
        }
    }


    void OnGUI()
    {

        if (!display)
        {
            FillTexture(Color.red);
            GUI.DrawTexture(new Rect(cursorPos.x, cursorPos.y, size, size), t);
        }
        else
        {
            FillTexture(Color.green);
            GUI.DrawTexture(new Rect(cursorPos.x, cursorPos.y, size, size), t);
        }
    }
    private void FillTexture(Color color)
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                t.SetPixel(x, y, color);
            }
        }
        t.Apply();
    }

}

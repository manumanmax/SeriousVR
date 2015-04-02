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
            Debug.Log(hitObject.tag);
            if (hitObject.tag.Equals("grabbable"))
            {
                display = true;
                Debug.Log("cursorColor found : " + dragOk);
                if (dragOk)
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(cursorPos.x, cursorPos.y, hit.distance));
                    worldPos = new Vector3(worldPos.x, worldPos.y, hitObject.transform.position.z);
                    hitObject.rigidbody.MovePosition(worldPos);
                    Debug.Log("dragging");
                }
            }
            else
            {
                display = false;
            }
        }


        if (dragOk)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance));
            worldPos = new Vector3(worldPos.x, worldPos.y, hitObject.transform.position.z);
            hitObject.rigidbody.MovePosition(worldPos);
            Debug.Log("dragging");
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

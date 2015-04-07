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
    public bool stopDrag = false;

    private GameObject objectDragged = null;
    private RaycastHit hitOfObjectDragged;

    private bool buttonDown;
    private bool buttonUp;


    private GameObject[] receivers;

    private void Awake()
    {

        Screen.lockCursor = true;
        buttonDown = false;
        buttonUp = false;

        receivers = GameObject.FindGameObjectsWithTag("receiver");
        t = new Texture2D(size, size, TextureFormat.RGB24, true);
        t.name = "Procedural Texture";
        FillTexture(Color.green);
        cursorPos = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            if (Screen.lockCursor)
                Screen.lockCursor = false;
            else
            {
                Screen.lockCursor = true;
            }

        if (Input.GetMouseButtonDown(0))
        {
            buttonUp = false;
            buttonDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            buttonUp = true;
            buttonDown = false;
        }

        ray = Camera.main.ScreenPointToRay(new Vector3(cursorPos.x, cursorPos.y, 0.0f));
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.transform.gameObject;
            //Debug.Log(hitObject);
            if (hitObject.tag.Equals("grabbable"))
            {
                display = true;
                if (Input.GetMouseButtonDown(0))
                {
                    objectDragged = hitObject;
                    hitOfObjectDragged = hit;
                    dragOk = true;
                }
            }
            else
            {
                if (!dragOk)
                    display = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragOk = false;
            display = false;

            objectDragged = null;
        }


        if (dragOk)
        {

            foreach (GameObject go in receivers)
            {

                Vector3 camToDraggred = objectDragged.transform.position - transform.position;
                Vector3 projection = Vector3.Project(camToDraggred, ray.direction) + transform.position;
                float distanceShootToDragged = Vector3.Distance(projection, go.transform.position);
                //Debug.DrawLine(projection, transform.position, Color.green);
                //Debug.Log(distanceShootToDragged);
                if (distanceShootToDragged < 2)
                {
                    if (go.GetComponent<ReceiverScript>().lockedObject == null)
                    {
                        go.GetComponent<ReceiverScript>().lockedObject = objectDragged;
                        stopDrag = true;
                    }
                }
                else
                {
                    // if current cube is the same that is locked
                    if (objectDragged.Equals(go.GetComponent<ReceiverScript>().lockedObject))
                    {
                        go.GetComponent<ReceiverScript>().lockedObject = null;
                    }
                    stopDrag = false;

                }


            }
        }
        if (!stopDrag && dragOk)
        {
            float distance = Vector3.Distance(camera.transform.position, objectDragged.transform.position);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(cursorPos.x, cursorPos.y, distance));
            worldPos = new Vector3(worldPos.x, worldPos.y, objectDragged.transform.position.z);
            objectDragged.transform.position = worldPos;
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

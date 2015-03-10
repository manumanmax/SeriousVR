using UnityEngine;
using System.Collections.Generic;

public class CreateObjects : MonoBehaviour
{
    public GameObject controller = new GameObject();
    public GameObject cube_1 = new GameObject();
    public GameObject cube_2 = new GameObject();
    public GameObject cube_3 = new GameObject();
    public GameObject storeArea = new GameObject();
    public GameObject dropArea = new GameObject();
    public GameObject resultArea = new GameObject();
    public GameObject storePanel = new GameObject();
    public GameObject dropPanel = new GameObject();
    public GameObject resultPanel = new GameObject();
    public GameObject lightGameObject;
    public GameObject dropLight;
    public Vector3 storeLightPos;
    public Vector4 lightColor;
    public float panelSpace;

    // Use this for initialization
    void Start()
    {
        panelSpace = 10.6f;

        controller = new GameObject();
        controller.AddComponent<CharacterController>();
        controller.AddComponent<MouseLook>();
        controller.AddComponent<Camera>();
        controller.AddComponent<GUILayer>();
        controller.AddComponent<CameraGrabber>();
        controller.tag = "MainCamera";
        //controller.AddComponent<MouseLook>();

        controller.transform.position = new Vector3((float)(15 - (panelSpace)), 5, 10);

        // cubes
        cube_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube_1.transform.position = new Vector3((float)(15 - (0)), 1, -2);
        cube_1.AddComponent<CursorColor>();
        Rigidbody r = new Rigidbody();
        cube_1.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; ;
        cube_1.AddComponent<BoxCollider>();
        cube_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube_2.transform.position = new Vector3((float)(15 - (1.5)), 1, -2);
        cube_2.AddComponent<CursorColor>();
        cube_2.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
        cube_2.AddComponent<BoxCollider>();
        cube_3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube_3.transform.position = new Vector3((float)(15 - (1.5)), 1, -2);
        cube_3.AddComponent<CursorColor>();
        cube_3.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ; ;
        cube_3.AddComponent<BoxCollider>();
        cube_1.AddComponent<RayCast>();
        cube_2.AddComponent<RayCast>();
        cube_3.AddComponent<RayCast>();


        // Areas
        storeArea = GameObject.CreatePrimitive(PrimitiveType.Plane);
        storeArea.name = "storeArea";
        storeArea.transform.position = new Vector3((float)(15 - (0)), 1, -4);
        dropArea = GameObject.CreatePrimitive(PrimitiveType.Plane);
        dropArea.transform.position = new Vector3((float)(15 - (panelSpace)), 1, -4);
        dropArea.name = "dropArea";
        resultArea = GameObject.CreatePrimitive(PrimitiveType.Plane);
        resultArea.transform.position = new Vector3((float)(15 - (2 * panelSpace)), 1, -4);
        resultArea.name = "resultArea";

        // Panels
        storePanel = GameObject.CreatePrimitive(PrimitiveType.Plane);
        storePanel.name = "storePanel";
        storePanel.transform.position = new Vector3((float)(15 - 0), 1, -4);
        storePanel.transform.position = storePanel.transform.position + new Vector3(0, 5, 0);
        storePanel.transform.Rotate(new Vector3(90, 0, 0));
        storePanel.transform.Translate(new Vector3(0, -4, -1));

        dropPanel = (GameObject)Instantiate(storePanel);
        dropPanel.transform.position = storePanel.transform.position + new Vector3(-(panelSpace), 0.0f, 0.0f);
        dropPanel.name = "dropPanel";
        resultPanel = (GameObject)Instantiate(dropPanel);
        resultPanel.transform.position = storePanel.transform.position + new Vector3(-(2 * panelSpace), 0.0f, 0.0f);
        resultPanel.name = "resultPanel";


        //lights
        storeLightPos = new Vector3(15.2f, 30f, -3.224f);
        lightColor = new Vector4(200, 172, 85, 255);
        lightGameObject = new GameObject("storeLight");
        lightGameObject.AddComponent<Light>();
        lightGameObject.light.color = lightColor;
        lightGameObject.light.type = LightType.Spot;
        lightGameObject.transform.position = storeLightPos;
        lightGameObject.light.intensity = 1;
        lightGameObject.light.range = 30f;
        lightGameObject.transform.Rotate(new Vector3(90, 0, 0));

        dropLight = (GameObject)Instantiate(lightGameObject);
        dropLight.transform.Translate(new Vector3(-panelSpace, 0, 0));
        dropLight.name = "dropLight";

        
        // cursor locking
        Screen.lockCursor = true;

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
    }

}
	


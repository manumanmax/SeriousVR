using UnityEngine;
using System.Collections;

public class ColoringForAlgorithm : MonoBehaviour
{

    private GameObject[] receivers;
    private bool receiversWellFilled;
    private GameObject[] cubes;
    public int numberOfCubes = 3;
    void Awake()
    {
        receivers = GameObject.FindGameObjectsWithTag("receiver");
        apply(Color.red, 1, 3);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in receivers)
        {
            if (go.GetComponent<ReceiverScript>().validObject == null)
            {
                receiversWellFilled = false;
                break;
            }
            receiversWellFilled = true;
        }

        if (receiversWellFilled)
        {
            Debug.Log("size of the contener : " + receivers.Length);
            foreach (GameObject go in receivers)
            {
                GameObject lockedObject = go.GetComponent<ReceiverScript>().lockedObject;
                if (lockedObject != null)
                    Debug.Log(go.GetComponent<ReceiverScript>().lockedObject.name);
            }
        }
    }
    void apply(Color initColor, int increment, int numberOfTimes)
    {
        if (numberOfTimes != numberOfCubes)
        {
            //TODO: change the texture of the result panel to fail
            return;
        }
        cubes = GameObject.FindGameObjectsWithTag("changinCube");

        Material red = Instantiate(Resources.Load("Materials/red", typeof(Material))) as Material;
        Debug.Log(red);

        for (int i = 0; i < numberOfTimes; i += increment)
        {
            if (i < 0)
            {
                //TODO: change the texture of the result panel to fail
            }
            else
            {
                cubes[i].renderer.material = red;
            }
        }

    }
}

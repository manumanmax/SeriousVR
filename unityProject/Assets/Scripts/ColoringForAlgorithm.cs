﻿using UnityEngine;
using System.Collections;

public class ColoringForAlgorithm : MonoBehaviour
{
    //algorithm final values
    Color color;
    int increment;
    int nbTimes;


    private GameObject[] receivers;
    private bool receiversWellFilled;
    private GameObject[] cubes;
    public int numberOfCubes = 3;
    void Awake()
    {
        receivers = GameObject.FindGameObjectsWithTag("receiver");



    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("size of the contener : " + receivers.Length);
        foreach (GameObject go in receivers)
        {
            Debug.Log(go.name + " is " + go.GetComponent<ReceiverScript>().validObject);
            if (go.GetComponent<ReceiverScript>().validObject == false)
            {
                receiversWellFilled = false;
                break;
            }

            receiversWellFilled = true;
        }

        if (receiversWellFilled)
        {
            
            foreach (GameObject go in receivers)
            {
                GameObject lockedObject = go.GetComponent<ReceiverScript>().lockedObject;
                if (lockedObject != null)
                {
                    parse(go.GetComponent<ReceiverScript>().lockedObject);
                }
                else
                {
                    break;
                }

            }
            apply(color, increment, nbTimes);
        }
    }

    private void parse(GameObject go)
    {
        Debug.Log(go.name);
        // type
        switch (go.GetComponent<Proprety>().name)
        {

            case "initialiser":
                color = getColor(go.name);
                break;
            case "increment":
                increment = getIncrement(go.name);
                break;
            case "loopNumber":
                nbTimes = getNbTimes(go.name);
                break;
            case "function":

                break;
            default:
                break;
        }


    }

    private Color getColor(string name)
    {
        switch (name)
        {
            case "green":
                return Color.green;
            case "blue":
                return Color.blue;
            case "grey":
                return Color.grey;
            case "yellow":
                return Color.yellow;
            case "red":
                return Color.red;
            default:
                return Color.white;
        }
    }

    private int getIncrement(string name)
    {
        switch (name)
        {
            case "i++":
                return 1;
            case "i--":
                return -1;
            default:
                char[] charName = name.ToCharArray();
                if (charName[1] == '-')
                {
                    return -(int.Parse(name.Substring(2, -1)));
                }
                else if (charName[1] == '+')
                {
                    return int.Parse(name.Substring(2, -1));
                }
                else
                {
                    return 1;
                }
        }
    }

    private int getNbTimes(string name)
    {
        return int.Parse(name);
    }

    void apply(Color initColor, int increment, int numberOfTimes)
    {
        Debug.Log("applying + " + initColor + "," + increment + "," + numberOfTimes);
        if (numberOfTimes > numberOfCubes)
        {
            //TODO: change the texture of the result panel to fail
            return;
        }
        cubes = GameObject.FindGameObjectsWithTag("changinCube");
        GameObject tmp = cubes[0];
        cubes[0] = cubes[2];
        cubes[2] = tmp;
        Material[] materials = new Material[numberOfCubes];
        materials[0] = (Instantiate(Resources.Load("Materials/red", typeof(Material))) as Material);
        materials[1] = (Instantiate(Resources.Load("Materials/green", typeof(Material))) as Material);
        materials[2] = (Instantiate(Resources.Load("Materials/blue", typeof(Material))) as Material);
        Debug.Log(materials);

        for (int i = 0; i < numberOfTimes; i += increment)
        {
            if (i < 0)
            {
                //TODO: change the texture of the result panel to fail
            }
            else
            {
                cubes[i].renderer.material = materials[i];
            }
        }

    }
}

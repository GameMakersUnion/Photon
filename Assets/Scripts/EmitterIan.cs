using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class EmitterIan : LightInteractable
{

    public Material material;

    LineRenderer line;
    List<Vector3> list = new List<Vector3>();
    Vector3 initialLightDir;
    bool isOutsideScreen;
    RaycastHit2D pastHit;
    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(1);
        line.SetPosition(0, transform.position);
        initialLightDir = Vector3.right; //new Vector3(1, 0);
        isOutsideScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyLine();
        SetPoint(transform.position, initialLightDir);
        MakeLine();

    }

    //is called recursively to draw the beam of light
    public void SetPoint(Vector3 origin, Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        //hit nothing!
        if (hit.collider == null)
        {
            list.Add(origin + direction * Screen.width);
            isOutsideScreen = true;
            return;
        }

        LightInteractable li = hit.collider.GetComponent<LightInteractable>();
        if (li == null)
        {
            Debug.LogWarning("<color=maroon>Your collider on " + hit.collider.name + " is missing a " + typeof(LightInteractable).Name + " component, dumb-nugget!</color>");
            list.Add(origin + direction * Screen.width);
            isOutsideScreen = true;
            return;
        }

        if (li.passable == true)
        {
            Debug.Log("TRUE");
        }
        else
        {
            Debug.Log("FALSE");
        }

        //hit somethign
        //else 
        {

            switch (hit.collider.tag)
            {
                case "Solid":
                    list.Add(hit.point);
                    break;
                case "Reflect":
                    list.Add(hit.point);
                    Debug.Log("Re flect!!");
                    break;
                case "Refract":
                    list.Add(hit.point);
                    Debug.Log("RE FRACT");
                    break;
                case "Switch":
                    list.Add(hit.point);
                    Debug.Log(hit.collider.name);
                    break;
                default:
                    break;
            }
            isOutsideScreen = false;

        }
    }


    private void MakeLine()
    {
        line.SetVertexCount(list.Count + 1);
        line.SetPosition(0, transform.position);
        for (int i = 0; i < list.Count; i++)
        {
            line.SetPosition(i + 1, list[i]);
        }
    }

    private void DestroyLine()
    {
        list = new List<Vector3>();
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Emitter : MonoBehaviour {
    LineRenderer line;
    List<Vector3> list = new List<Vector3>();
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetPosition(0, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cursorPos = Input.mousePosition;
        Vector3 clickPosAtCamera = Camera.main.ScreenToWorldPoint(cursorPos);
        Vector3 clickPos = new Vector3(clickPosAtCamera.x, clickPosAtCamera.y, transform.position.z);
        Debug.Log(clickPos);
        //if (Input.GetMouseButtonDown(0))
        {

            line.SetPosition(1, clickPos);
        }

	}

    //is called recursively to draw the beam of light
    public void SetPoint(Vector3 origin, Vector3 direction) {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        switch (hit.collider.tag)
        {
            case "Solid":
                list.Add(hit.point);
                break;
            case "Reflect":
                list.Add(hit.point);
                Reflect(hit, direction);
                break;
            case "Refract":
                list.Add(hit.point);
                Refract(hit, direction);
                break;
            default:
                break;
        }

    }

    //calls setPoint at the end
    private void Reflect(RaycastHit2D hit, Vector3 direction) { }

    // calls setPoint
    private void Refract(RaycastHit2D hit, Vector3 direction) { }
}

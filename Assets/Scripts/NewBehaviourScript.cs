using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 cursorPos = Input.mousePosition;
        Vector3 clickPosAtCamera = Camera.main.ScreenToWorldPoint(cursorPos);
        Vector3 clickPos = new Vector3(clickPosAtCamera.x, clickPosAtCamera.y, transform.position.z);
        Debug.Log(clickPos);

	}
}

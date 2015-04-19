using UnityEngine;
using System.Collections;

public class LightInteractable : MonoBehaviour
{

    //most cases are false;
    private bool passable_ = false;

    public bool passable
    {
        get { return passable_; }
        protected set { passable_ = value; }
    }


    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

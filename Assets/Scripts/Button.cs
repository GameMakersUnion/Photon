using UnityEngine;
using System.Collections;

public class Button : LightInteractable {

    private bool state_ = false;
    public bool state
    {
        get { return state_; }
        private set { state_ = value; }
    }

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        passable = true;
	    sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetButton(bool state, Color color)
    {
        state_ = state;
        sr.color = color;
    }
    
}

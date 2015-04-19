using UnityEngine;
using System.Collections;

public class Switch : LightInteractable {

    private bool state_ = false;
    public bool state
    {
        get { return state_; }
        private set { state_ = value; }
    }

    private SpriteRenderer sr;
    private Color origColor; 

	// Use this for initialization
	void Start () {
        passable = true;
	    sr = GetComponent<SpriteRenderer>();
	    origColor = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToggleSwitch(Color color)
    {
        state_ = !state_;
        passable = !passable;
        sr.color = (state) ? color : origColor;
    }
}

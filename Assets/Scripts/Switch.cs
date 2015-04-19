using UnityEngine;
using System.Collections;

public class Switch : LightInteractable {

    private bool state_ = false;
    public bool state
    {
        get { return state_; }
        private set { state_ = value; }
    }

	// Use this for initialization
	void Start () {
        passable = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSwitch(bool state)
    {
        state_ = state;
    }
    
    private void ToggleSwitch()
    {
        
    }
}

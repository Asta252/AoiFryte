using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : Token {
    public static TokenMgr<Life> parent = null;
    public static Life Add(float x,float y,int num)
    {
        return parent.Add(x + 16 * num, y);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

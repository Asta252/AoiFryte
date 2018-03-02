using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : Token {
    public static TokenMgr<Shot> parent = null;

    public static Shot Add(float x,float y,float direction,float speed)
    {
        return parent.Add(x, y, direction, speed);
    }
	// Use this for initialization
	void Start () {
        this.transform.Rotate(0, 0, Random.Range(0, 360));
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, 3);

        if (IsOutside())
        {
            Vanish();
        }
	}

    public override void Vanish()
    {
        Particle p = Particle.Add(X, Y);
        if (p != null)
        {
            p.SetColor(0.1f, 0.1f,1);
            p.MulVelocity(0.7f);
        }
        base.Vanish();
    }
}

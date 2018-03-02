using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Shot.parent = new TokenMgr<Shot>("Shot", 32);
        Particle.parent = new TokenMgr<Particle>("Particles", 256);
        Bullet.parent = new TokenMgr<Bullet>("Bullet", 256);

        Enemy.target = GameObject.Find("Player").GetComponent<Player>();
        //Life.parent = new TokenMgr<Life>("life", 8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

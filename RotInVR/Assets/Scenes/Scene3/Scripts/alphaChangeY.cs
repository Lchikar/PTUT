using System;
using UnityEngine;

public class alphaChangeY : MonoBehaviour {

    private Renderer wallRenderer;
	public float alpha = 0f;
	public Transform player;
	private double dist;

    // Start is called before the first frame update
    void Start() {
        wallRenderer = GetComponent<Renderer>();
    	wallRenderer.material.color = new Color(1f, 1f, 1f, alpha);
    
    }

    // Update is called once per frame
    void Update() {
    	dist = Math.Sqrt(Math.Pow(player.position.z - transform.position.z, 2));
		if(dist<4) {
	    	alpha = (float) (0.75 - dist/5);
    	}
    	else {
    		alpha = 0f;
    	}
    	wallRenderer.material.color = new Color(1f, 1f, 1f, alpha);
    }
}

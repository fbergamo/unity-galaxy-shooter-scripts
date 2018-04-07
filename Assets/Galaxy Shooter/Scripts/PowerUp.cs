using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float speed = 1f;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null) {  
               player.TripleShotPowerUp();
               Destroy(this.gameObject);
            }
        }
    }

    
}

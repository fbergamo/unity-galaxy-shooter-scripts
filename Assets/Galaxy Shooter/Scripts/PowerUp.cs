using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float speed = 1f;

    [SerializeField]
    private int powerupID;

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
                if(powerupID == 0)
                {
                    player.TripleShotPowerUp();
                } else if (powerupID == 1)
                {
                    player.SpeedPowerUp();
                } else if (powerupID == 2)
                {
                    player.ShieldPowerUp();
                }
                Destroy(this.gameObject);
            }
        }
    }

    
}

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();  //  find player controller in scene and assign it to the player
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");

    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);   //  death particle
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;    //  stop player movement once they die
        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = currentCheckpoint.transform.position; //    respawn at checkpoint

        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true; //  allow player movement once respawned

        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);   //  respawn particle
    }
}

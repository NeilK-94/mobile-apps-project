using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();  //  find player controller in scene and assign it to the player
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }
}

using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;   //  create empty level manager of type LevelManager

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();    //  finds any objects in scene that have LevelManager with it
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }

}

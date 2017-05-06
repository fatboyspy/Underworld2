using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public GameObject enemyBody;
	public GameObject gamer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
	}
	void OnMouseOver()
	{
		gamer=GameObject.FindGameObjectWithTag("Player");
		//((PlayerControl)gamer.GetComponent(typeof(PlayerControl))).target
	}
}

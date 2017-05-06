using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// скрипт контроллирует начало игры:
/// спавн персонажа
/// </summary>
public class StartGame : MonoBehaviour {
	
	public Vector3 gamerSpawnPoint;
	public PlayerControl gamerController;
	public GameObject gamerModel;
	public UnityEngine.Object gamerObject;
	// Use this for initialization
	void Start () {
		gamerSpawnPoint=new Vector3(438f,60.7f,2767f);
		SpawnGamer();		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SpawnGamer()
	{		
		string[] gamerInfo = PlayerPrefs.GetString("underworld_character").Split(';');
        Gamer gamer = new Gamer(gamerInfo[0], (PlayerRace)Convert.ToInt32(gamerInfo[1]), (CreatureGender)Convert.ToInt32(gamerInfo[2]), (PlayerOccupation)Convert.ToInt32(gamerInfo[3]), Convert.ToInt32(gamerInfo[4]), Convert.ToInt32(gamerInfo[5]), Convert.ToInt32(gamerInfo[6]), Convert.ToInt32(gamerInfo[7]), Convert.ToInt32(gamerInfo[8]), Convert.ToInt32(gamerInfo[9]), Convert.ToInt32(gamerInfo[10]), Convert.ToInt32(gamerInfo[11]));
		gamerModel = (GameObject)Resources.Load("Models/PlayerModels/" + gamer.Race.ToString() + "/" + gamer.Gender.ToString() + "/" + gamer.Occupation.ToString() + "/Prefab/ModelPrefab");
        gamerModel.AddComponent(typeof(PlayerControl));
		((CharacterController)gamerModel.GetComponent(typeof(CharacterController))).center=new Vector3(0f,0.98f,0f);
		gamerModel.name=gamer.Name;
		gamerObject=Instantiate(gamerModel,gamerSpawnPoint,Quaternion.AngleAxis(180, Vector3.up));
		
		GameObject go=GameObject.FindGameObjectWithTag("MainCamera");
        gamer.Inventory.AddItem(ItemsLibrary.items[0]);
        gamer.Inventory.AddItem(ItemsLibrary.items[1]);
        gamer.Inventory.AddItem(ItemsLibrary.items[2]);
        gamer.CalculateCurrentLoad();
		((GameView)go.GetComponent(typeof(GameView))).targetGamer=gamer;
	}
}

using UnityEngine;
using System.Collections;

class SpawnManager : MonoBehaviour {
	public Mob[] mobs;
	public SpawnPoint[] spawnPoints;
	public DropList[] dropLists;
	public UnityEngine.Object[] spawnedObjects;
	public GameObject go;
	// Use this for initialization
	void Start () {
		spawnPoints=SpawnPointsLibrary.spawnPoints;
		spawnedObjects=new UnityEngine.Object[spawnPoints.Length];
		SpawnMobs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SpawnMobs()
	{
		int index=0;
		foreach(SpawnPoint sp in spawnPoints)
		{
			go=(GameObject)Resources.Load("Models/MobModels/"+sp.Mob.Name+"/"+"Prefab/ModelPrefab");
			go.name=sp.Mob.Name;
			go.AddComponent(typeof(EnemyAI));
			((EnemyAI)go.GetComponent(typeof(EnemyAI))).enemyBody=go;
			go.AddComponent(typeof(CharacterController));
			//((CharacterController)go.GetComponent(typeof(CharacterController))).height=1;
			
			spawnedObjects[index]=Instantiate(go,sp.Point,Quaternion.AngleAxis(180, Vector3.up));
			index++;
		}
	}
}

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
        for (int i = 0; i < spawnedObjects.Length; i++)
        {
            if (spawnedObjects[i] != null)
            {
                if (((EnemyAI)((GameObject)spawnedObjects[i]).GetComponent(typeof(EnemyAI))).mob.CurrentHealthPoints <= 0)
                {
                    string mobName = ((EnemyAI)((GameObject)spawnedObjects[i]).GetComponent(typeof(EnemyAI))).mob.Name;
                    Destroy(spawnedObjects[i], 6);
                }
            }
            else
            {
                go = (GameObject)Resources.Load("Models/MobModels/" + spawnPoints[i].Mob.Name + "/" + "Prefab/ModelPrefab");
                go.name = spawnPoints[i].Mob.Name;
                ((EnemyAI)go.GetComponent(typeof(EnemyAI))).enemyBody = go;
                ((EnemyAI)go.GetComponent(typeof(EnemyAI))).name = spawnPoints[i].Mob.Name;
                
                ((CharacterController)go.GetComponent(typeof(CharacterController))).height = 1;
                ((CharacterController)go.GetComponent(typeof(CharacterController))).center = new Vector3(0f, 0.4f, 0f);
                spawnedObjects[i] = Instantiate(go, spawnPoints[i].Point, Quaternion.AngleAxis(180, Vector3.up));
            }
        }
	
	}
	void SpawnMobs()
	{
		int index=0;
		foreach(SpawnPoint sp in spawnPoints)
		{
        
			go=(GameObject)Resources.Load("Models/MobModels/"+sp.Mob.Name+"/"+"Prefab/ModelPrefab");
            go.name=sp.Mob.Name;
			//go.AddComponent(typeof(EnemyAI));
            ((EnemyAI)go.GetComponent(typeof(EnemyAI))).enemyBody = go;
            ((EnemyAI)go.GetComponent(typeof(EnemyAI))).name = sp.Mob.Name;
			//go.AddComponent(typeof(CharacterController));
			((CharacterController)go.GetComponent(typeof(CharacterController))).height=1;
            ((CharacterController)go.GetComponent(typeof(CharacterController))).center = new Vector3(0f,0.4f,0f);


			spawnedObjects[index]=Instantiate(go,sp.Point,Quaternion.AngleAxis(180, Vector3.up));
          	index++;
		}
	}
}

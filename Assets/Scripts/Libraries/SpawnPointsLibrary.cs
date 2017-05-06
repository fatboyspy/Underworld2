using UnityEngine;
using System.Collections;

public static class SpawnPointsLibrary {
	public static SpawnPoint[] spawnPoints=new SpawnPoint[]
	{
		new SpawnPoint(MobsLibrary.mobs[0],new Vector3(723.6667f, 61.34455f, 2690.317f)),
        new SpawnPoint(MobsLibrary.mobs[1],new Vector3(755.551f, 62.19212f, 2645.567f)),
        new SpawnPoint(MobsLibrary.mobs[2],new Vector3(821.5221f, 54.87345f, 2604.747f)),
        new SpawnPoint(MobsLibrary.mobs[3],new Vector3(863.0769f, 46.11952f, 2642.69f)),
        new SpawnPoint(MobsLibrary.mobs[4],new Vector3(901.0789f, 37.94343f, 2715.42f))
	};

}

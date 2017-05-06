using UnityEngine;
using System.Collections;

public class SpawnPoint 
{
	Mob mob;
	Vector3 point;
	
	public Mob Mob {
		get {
			return this.mob;
		}
		set {
			mob = value;
		}
	}

	public Vector3 Point {
		get {
			return this.point;
		}
		set {
			point = value;
		}
	}
	
	/// <summary>
	// конструктор без параметров
	/// </summary>
	public SpawnPoint()
	{
	}
	
	public SpawnPoint(Mob mob, Vector3 point)
	{
		this.mob=mob;
		this.point=point;
	}
}

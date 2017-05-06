using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
    GameObject target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

    }
    void OnGUI()
    {
    }
}

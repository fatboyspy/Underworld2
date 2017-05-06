using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    public float
            xSpeed,
            ySpeed,
            zoomSpeed,
            limitZoom;

    public Transform target;
    private float x, y, distance = 5;

    void Start()
    {
        //target = GameObject.Find("Player").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        xSpeed = 120f;
        ySpeed = 120f;
        zoomSpeed = 60f;
        limitZoom = 20f;

        x += (float)(Input.GetAxis("Mouse X") * xSpeed);
        y -= (float)(Input.GetAxis("Mouse Y") * ySpeed);

        transform.rotation = Quaternion.Euler(y, x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        distance -= (float)(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);

        if (distance < 2) distance = 2;
        if (distance > limitZoom) distance = limitZoom;

        if (Input.GetMouseButton(1))
        {
            x += (float)(Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime);
            y -= (float)(Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime);

            if (x > 360) x = 1;
            if (x < 0) x = 360;

            if (y < 0) y = 0;
            if (y > 90) y = 90;

            transform.rotation = Quaternion.Euler(y, x, 0);
        }
        transform.position = transform.rotation * new Vector3(0, 1, -distance) + target.position;
    }
}
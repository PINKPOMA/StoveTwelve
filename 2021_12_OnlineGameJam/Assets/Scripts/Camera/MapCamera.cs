using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public Camera camera;
    public Transform target;
    public float y = 28.8f;

    private void Update()
    {
        camera.transform.position = new Vector3(0, Mathf.FloorToInt((target.position.y + y * 0.5f)/ y)*y, -10);
    }
}

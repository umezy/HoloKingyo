using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    GameObject player = null;
    Vector3 offset = Vector3.zero;

    void Start()
    {
        player = GameObject.Find("kingyoModel");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        offset.y = 1f;
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + offset.x;
        newPosition.y = player.transform.position.y + offset.y;
        newPosition.z = player.transform.position.z + offset.z;
        transform.position = newPosition;
    }
}
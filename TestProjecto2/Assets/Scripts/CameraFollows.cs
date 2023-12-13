using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [SerializeField] private Transform _followObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(_followObject.position.x, _followObject.position.y, -10f );
        transform.position = newPos;
    }
}

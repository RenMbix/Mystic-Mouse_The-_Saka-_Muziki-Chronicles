using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    // Cam startpos on target (hero/player)

    public Transform target = null;

    //offset

    private Vector3 offset;



    // Start is called before the first frame update
    void Start()
    {
        //offset position
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // late update and Lerp Smmothen camera movement
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0, target.position.z) + offset, Time.deltaTime * 3);
    }
}

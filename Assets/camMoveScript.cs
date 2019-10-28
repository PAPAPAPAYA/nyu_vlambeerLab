using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveScript : MonoBehaviour
{
    static public camMoveScript me;
    public float camHeight = 5;

    public float spd;
    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camDstn = new Vector3 (GameManager.me.center.x, camHeight, GameManager.me.center.z);
        transform.position = Vector3.Lerp(transform.position,camDstn,spd * Time.deltaTime);
    }
}

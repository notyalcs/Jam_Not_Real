using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject player;
    
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var tempTransform = player.transform.position;
        float x = Mathf.Clamp(tempTransform.x, xMin, xMax);
        float y = Mathf.Clamp(tempTransform.y, yMin, yMax);

        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y + y, gameObject.transform.position.z);
    }
}

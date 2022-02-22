using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShift : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    private Vector3 _destination;
    private bool _shiftedBack;
    private bool _shiftedForward = true;

    private bool _moving = false;
    
    // Update is called once per frame
    private void Update()
    {
        Shift();
    }

    private void Shift()
    {
        var pos = transform.position;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_shiftedBack) return;
            _destination = new Vector3(pos.x, pos.y, pos.z + 3);
            _moving = true;
            _shiftedBack = true;
            _shiftedForward = false;
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            if (_shiftedForward) return;
            _destination = new Vector3(pos.x, pos.y, pos.z - 3);
            _moving = true;
            _shiftedForward = true;
            _shiftedBack = false;
        }

        if (_moving && transform.position != _destination)
        {
            transform.position = Vector3.MoveTowards(pos, _destination, moveSpeed * Time.deltaTime);
        }
        else
        {
            _moving = false;
        }
        
    }
}
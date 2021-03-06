using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShift : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;

    private bool day = true;

    public float moveSpeed;
    private Vector3 _destination;
    private int _state = -4;
    private PlayerController _pc;
    private bool _moving = false;

    private void Start()
    {
        _pc = GetComponent<PlayerController>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SwitchState();
        Shift();
    }

    private void SwitchState()
    {
        if (_moving) return;

        day = !day;
        RenderSettings.skybox = day ? daySkybox : nightSkybox;

        _state = -_state;
        var pos = transform.position;
        _destination = new Vector3(pos.x, pos.y, pos.z + _state);
        _moving = true;
    }

    private void Shift()
    {
        var pos = transform.position;

        if (_moving && transform.position != _destination)
        {
            _pc.enabled = false;
            transform.position = Vector3.MoveTowards(pos, _destination, moveSpeed * Time.deltaTime);
        }
        else
        {
            _pc.enabled = true;
            _moving = false;
        }
    }
}
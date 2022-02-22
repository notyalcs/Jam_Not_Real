using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject player;
    public float followSpeed;
    public float offsetOffset;
    private float _offsetY;
    private float _offsetZ;
    private Vector3 _pos;

    private void Start()
    {
        _pos = transform.position;
        _offsetY = _pos.y;
        _offsetZ = _pos.z;
    }

    private void FixedUpdate()
    {
        _pos = transform.position;
        var dest = player.transform.position;
        transform.position = Vector3.MoveTowards(
            _pos, new Vector3(dest.x, dest.y  + _offsetY - offsetOffset / 2, dest.z + _offsetZ + offsetOffset), followSpeed * Time.deltaTime);
    }
}

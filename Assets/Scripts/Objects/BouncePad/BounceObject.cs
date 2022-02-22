using UnityEngine;

public class BounceObject : MonoBehaviour
{
    public float bounceStrength;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("some");
        other.GetComponent<PlayerController>().rb.AddForce(0, bounceStrength, 0);
    }
}

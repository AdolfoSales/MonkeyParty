using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoleyNet : MonoBehaviour
{
    [SerializeField]
    private LostZoneVoleyCoco left, right;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Vector3 dir = (collision.transform.position - transform.position).normalized;
            if (dir.x > 0)
            {
                right.AddPoints();
            }
            else
            {
                left.AddPoints();
            }
        }
    }
}

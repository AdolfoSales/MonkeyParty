using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttachment : MonoBehaviour
{
    private Transform ball;

    [SerializeField]
    private float gapY;

    public void InitAvatar(Transform _ball)
    {
        ball = _ball;
        Vector3 pos = ball.position;
        pos.y = ball.position.y + gapY;
        transform.position = pos;
    }


    private void LateUpdate()
    {
        Vector3 pos = ball.position;
        pos.y = transform.position.y;
        transform.position = pos;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChasingCamera : MonoBehaviour
{
    // 플레이어 위치
    public Transform target;

    // 천천히 따라가는 속도 조정 수치
    public float chase_speed = 1.0f;

    // 플레이어와 카메라간 거리
    public Vector3 offset;

    private void Update()
    {
        Vector3 final_target = target.position + offset;
        Vector3 slow_chase_player_target = Vector3.Lerp(transform.position, final_target, chase_speed * Time.deltaTime);

        transform.position = new Vector3(slow_chase_player_target.x, slow_chase_player_target.y, transform.position.z);
    }
}

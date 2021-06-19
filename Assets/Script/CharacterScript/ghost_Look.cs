using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_Look : MonoBehaviour
{
    public GameObject Player;

    [Tooltip("回転スピード")]
    public float direction_speed;

    [Tooltip("Quaternion LookRotation 軸")]
    public Vector3 XYZ;
    /// <summary>
    /// 幽霊がプレーヤーを見れるようにする
    /// </summary>
    void LateUpdate()
    {
        Vector3 direction = Player.transform.position - transform.position * direction_speed;
        direction.y = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(direction,XYZ);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, direction_speed);
    }
}

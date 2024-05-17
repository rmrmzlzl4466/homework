using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // 타겟 오브젝트
    public float orbitSpeed = 10f; // 회전 속도

    void Update()
    {
        if (target != null)
        {
            // 타겟 주위를 회전
            transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}

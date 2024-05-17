using UnityEngine;

public class FireworkSound : MonoBehaviour
{
    public ParticleSystem fireworkParticles; // 파티클 시스템 연결
    public AudioSource audioSource;          // 오디오 소스 연결

    void Start()
    {
        fireworkParticles.Play(); // 파티클 시스템 재생
    }

    // 파티클 시스템의 이벤트에 따라 사운드 재생
    void Update()
    {
        if (fireworkParticles.isEmitting && !audioSource.isPlaying)
        {
            audioSource.Play(); // 사운드 재생
        }
    }
}


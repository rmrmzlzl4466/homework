using UnityEngine;
using System.Collections;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem particleSystem; // 제어할 파티클 시스템
    public float loopDuration = 30f; // 루프 주기 (초)
    public float fadeDuration = 5f; // 페이드 시간 (초)

    void Start()
    {
        StartCoroutine(ParticleLoop());
    }

    IEnumerator ParticleLoop()
    {
        while (true)
        {
            // 파티클 시스템 실행
            particleSystem.Play();

            // loopDuration - fadeDuration 초 동안 대기
            yield return new WaitForSeconds(loopDuration - fadeDuration);

            // 파티클 시스템 점점 멈추기
            float elapsedTime = 0f;
            var emission = particleSystem.emission;

            while (elapsedTime < fadeDuration)
            {
                emission.rateOverTime = Mathf.Lerp(emission.rateOverTime.constant, 0f, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 파티클 시스템 정지
            particleSystem.Stop();

            // fadeDuration 초 동안 대기 (파티클이 완전히 사라지도록)
            yield return new WaitForSeconds(fadeDuration);
        }
    }
}


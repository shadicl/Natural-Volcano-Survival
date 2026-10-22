using System.Collections;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] private AudioSource meteorHit;
    [SerializeField] private AudioSource walkSFX;
    [SerializeField] private AudioSource runSFX;

   public void PlayMeteorHit()
   {
        meteorHit.Play();
   }

    public void PlayWalkSFX(float duration)
    {

        if (!walkSFX.isPlaying)
        {
            runSFX.Stop();
            walkSFX.Play();
            StartCoroutine(Delay(duration));
        }
    }

    public void PlayRunSFX(float duration)
    {

        if (!runSFX.isPlaying)
        {
            walkSFX.Stop();
            runSFX.Play();
            StartCoroutine(Delay(duration));
        }
    }

    public void StopWalkSFX()
    {
        walkSFX.Stop();
    }

    public void StopWalkRunSFXs()
    {
        walkSFX.Stop();
        runSFX.Stop();
    }

    private IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}

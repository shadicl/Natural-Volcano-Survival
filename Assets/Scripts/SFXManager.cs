using System.Collections;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] private AudioSource meteorHit;
    [SerializeField] private AudioSource walkSFX;
    [SerializeField] private AudioSource runSFX;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource victorySFX;
    [SerializeField] private AudioSource volcanoSelectSFX;

   public void PlayMeteorHit()
   {
        meteorHit.Play();
   }

    public void PlayWalkSFX()
    {

        if (!walkSFX.isPlaying)
        {
            runSFX.Stop();
            walkSFX.Play();
        }
    }

    public void PlayRunSFX()
    {

        if (!runSFX.isPlaying)
        {
            walkSFX.Stop();
            runSFX.Play();
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

    public void PlayJumpSFX()
    {
        jumpSFX.Play();
    }

    public void PlayVictorySFX()
    {
        victorySFX.Play();
    }

    public void PlayVolcanoSelectSFX()
    {
        volcanoSelectSFX.Play();
    }
}

using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] private AudioSource meteorHit;

   public void PlayMeteorHit()
    {
        meteorHit.Play();
    }
}

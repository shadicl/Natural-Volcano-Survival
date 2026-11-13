using System.Collections;
using UnityEngine;

public class Parry : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private float parryDuration = 3f;
    [SerializeField] private float parryCooldown = 5f;

    [SerializeField] private float flashDuration = 0.5f;

    [SerializeField] private AudioSource parryInitiate;
    [SerializeField] private AudioSource parrySuccess;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private Coroutine parryCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TryParry()
    {

        if (!player.canParry)
        {
            return;
        }

        parryInitiate.Play();
        parryCoroutine = StartCoroutine(ParryCoroutine());
    }

    public void Flash(Color color)
    {
        StartCoroutine(FlashCoroutine(color));
    }

    private IEnumerator FlashCoroutine(Color c)
    {
        spriteRenderer.color = c;

        float elaspedTime = 0f;

        while (elaspedTime < flashDuration)
        {
            elaspedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elaspedTime / flashDuration);

            spriteRenderer.color = Color.Lerp(Color.white, originalColor, t);

            yield return null;
        }

        spriteRenderer.color = originalColor;
    }

    private IEnumerator ParryCoroutine()
    {
        player.canParry = false;
        player.isParrying = true;

        yield return new WaitForSeconds(parryDuration);

        player.isParrying = false;

        yield return new WaitForSeconds(parryCooldown);

        player.canParry = true;
        parryCoroutine = null;
    }

    public void SuccessfulParry()
    {

        if (!player.isParrying)
        {
            return;
        }

        if (parryCoroutine != null)
        {
            StopCoroutine(parryCoroutine);
            parryCoroutine = null;
        }

        parrySuccess.Play();

        player.isParrying = false;
        player.canParry = true;

        print("Successful parry!");
    }
}

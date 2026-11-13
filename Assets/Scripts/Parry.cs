using System.Collections;
using UnityEngine;

public class Parry : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private float parryDuration = 3f;

    [SerializeField] private float flashDuration = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(parryDuration);
        player.parrying = false;
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = Color.white;

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
}

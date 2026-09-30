using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        image.fillAmount = health / maxHealth;
    }
}

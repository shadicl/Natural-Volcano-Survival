using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateSprint(float currentStamina, float maxStamina)
    {
        image.fillAmount = currentStamina / maxStamina;
    }
}

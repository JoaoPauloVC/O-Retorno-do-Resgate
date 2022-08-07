using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 OffSet;


    public void SetHealth (float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth); //Show health bar if enemy take damage
        Slider.value = health; // actual health
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue); // supposed to show remain Health, but its not working
    }

    void FixedUpdate()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + OffSet); // HealthBar moves with enemy.
    }
}

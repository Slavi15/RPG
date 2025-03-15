using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Animator animator;

    void Start()
    {
        ChangeText();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        animator.Play("TextUpdate");
        ChangeText();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void ChangeText()
    {
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }

}

using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "ScriptableObjects/Variable/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float maxHealth;
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    [SerializeField]
    private float _currentHealth;

    [Multiline]
    public string DeveloperDescription = "";

    public void Heal(float amount)
{
    currentHealth += amount;

    if (currentHealth > maxHealth)
    {
        currentHealth = maxHealth;
    }
}

}



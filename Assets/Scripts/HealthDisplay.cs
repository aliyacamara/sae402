using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [Header("Glisse ton fichier PlayerData ici :")]
    public PlayerData playerData;

    [Header("Glisse tes 4 images de pommes ici :")]
    public GameObject[] appleIcons; 

    void Update()
    {
        if (playerData != null && appleIcons.Length > 0)
        {
            for (int i = 0; i < appleIcons.Length; i++)
            {
                
                appleIcons[i].SetActive(i < playerData.currentHealth);
            }
        }
    }
}
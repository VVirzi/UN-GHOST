using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipiente : MonoBehaviour, IInteractable
{
    private string enemyID;
    [SerializeField] private MeshRenderer centerMaterial;
    [SerializeField] private RecipientsData recipientsData;
    [SerializeField] private LevelManager levelManager;
    private bool canInteract = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (canInteract)
        {
            if (centerMaterial.material != null)
            {
                enemyID = LevelManager.lastEnemyKilled;
                if (enemyID != null)
                {
                    ChangeMaterial(enemyID);
                    LevelManager.lastEnemyKilled = null;
                    levelManager.RecipientesEvent?.Invoke();
                    canInteract = false;
                }
            }
        }
    }

    private void ChangeMaterial(string enemyID)
    {
        switch(enemyID)
        {
            case "Disparito":
                centerMaterial.material = recipientsData.Disparito;
                break;
            case "Tornado":
                centerMaterial.material = recipientsData.Tornado;
                break;
            case "Toxic":
                centerMaterial.material = recipientsData.Toxic;
                break;
            default:
                break;
        }
    }
}

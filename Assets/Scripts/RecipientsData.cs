using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipientsData", menuName = "RecipienteMateriales", order = 0)]
public class RecipientsData : ScriptableObject
{
    [field: SerializeField] public Material Disparito { get; private set; }
    [field: SerializeField] public Material Toxic { get; private set; }
    [field: SerializeField] public Material Tornado { get; private set; }

}

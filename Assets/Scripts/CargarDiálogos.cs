using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CargarDiálogos : MonoBehaviour
{
    [SerializeField] private TextAsset file;
    private List<string> dialogueText = new List<string>();
    [SerializeField] private TextMeshProUGUI textComp;

    private int index;
    private float textSpeed = 0.1f;
    void Start()
    {
        //textComp = GetComponent<TextMesh>();
        textComp.text = string.Empty;
        DialogueToList();
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComp.text == dialogueText[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
            }
        }
    }

    private void DialogueToList()
    {
        dialogueText = file.text.Split("\n").ToList();
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in dialogueText[index].ToCharArray())
        {
            textComp.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < dialogueText.Count -1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

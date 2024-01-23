using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NPCDialogSystem : MonoBehaviour
{
    [field: SerializeField] public NPCDialogSO NPCDialog { get; private set; }
    public GameObject dialogPanel;
    public Image NPCImage;
    public TMP_Text NPCName;
    public TMP_Text dialogText;
    public GameObject continueButton;

    public GameObject iconInteraction;
    private PlayerInput _playerInput;

    public string[] dialog;
    private int index;

    
    public float wordSpeed;
    public bool playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        NPCImage.sprite = NPCDialog.NPCSprite;
        NPCName.text = NPCDialog.NPCName;
        dialog = NPCDialog.Dialogs;
        iconInteraction.SetActive(false);
    }

    public void StartDialog(InputAction.CallbackContext ctx)
    {

        if (ctx.phase == InputActionPhase.Performed && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogText.text == dialog[index]) continueButton.SetActive(true);
    }

    public void ZeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        if (index < dialog.Length-1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        iconInteraction.SetActive(true);
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        iconInteraction.SetActive(false);
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
}

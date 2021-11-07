using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform FaceImage;
    public Transform NPCCharacter;
    public GameObject Player;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () 
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
	
	//void Update () 
    //{
         // Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
         // Pos.y += 0;
          //ChatBackGround.position = Pos;
    //}

    public void OnTriggerStay(Collider collider)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((collider.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            FaceImage.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
            Debug.Log("HELLOOOOOO IS THIS WORKING");


        }
        if ((collider.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.T))
        {
            FaceImage.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
            Debug.Log("HELLOOOOOO IS THIS WORKING");


        }
    }

    public void OnTriggerExit(Collider collider)
    {     
        collider.gameObject.SetActive(true);
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
        FaceImage.gameObject.SetActive(false);
        Debug.Log("HELLOOOOOO IS THIS WORKING");
        


    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [Header("Components")]

    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //Referenciar a fala do npc
    public Text actorNameText; //Referenciar o nome do npc

    [Header("Settings")]
    public float typingSpeed; //Velocidade que o texto ira aparecer
    private bool isShowing; //se a janela esta visivel
    private int index; //saber a quantidade de textos que tem numa fala.
    private string[] sentences;

    public static DialogueControl instance;

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed); //Para controlar o tempo
        }
    }


    public void NextSentence()
    {

    }


    public void Speech(string[] txt)
    {

        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }

    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

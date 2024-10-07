using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string Code = "5431";
    private string Nr = null;
    public TextMeshProUGUI text = null;

    public GameObject box;
    public GameObject openBox;

    private MouseLookAround mouse;
    private InteractWithObject interact;

    

    private void Start() {
        mouse = GameObject.FindObjectOfType<MouseLookAround>();
        interact = GameObject.FindObjectOfType<InteractWithObject>();
    }

    private void Update() {
        if(text.text.Length > 4){
            Delete();
        }
    }

    public void CodeFunction(string num){
        Nr = Nr + num;
        text.text = Nr;
    }

    public void CheckPassword(){
        if(text.text.Length == 4 && text.text == Code){
            text.color = Color.green;
            text.text = "Correct";
            Destroy(box);
            openBox.gameObject.SetActive(true);

            Invoke("Delete", 1);
        }
        else if(text.text.Length <= 4 && text.text != Code)
        {
            Delete();
        }
    }

    private void Delete()
    {
        Nr = null;
        text.text = Nr;
    }

    public void Exit(){
        Delete();
        transform.gameObject.SetActive(false);
        //interact.Exit(1);
        mouse.StopLook(0);
        text.text = null;
    }
}

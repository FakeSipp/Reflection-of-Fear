using UnityEngine;
using UnityEngine.UI;

public class ComputerPad : MonoBehaviour
{
    public string Code = "363244";
    private string numberOfWord = null;
    private string Nr = null;
    public Text text = null;

    public GameObject hiddenDoor;

    private MouseLookAround mouse;
    private InteractWithObject interact;

    
    private void Start() {
        mouse = GameObject.FindObjectOfType<MouseLookAround>();
        interact = GameObject.FindObjectOfType<InteractWithObject>();
    }

    private void Update() {
        if(text.text.Length > 6){
            Delete();
        }
    }


    public void CodeFunction(string num){
        numberOfWord = numberOfWord + num;
        Nr = Nr + "*";
        text.text = Nr;
    }

    public void CheckPassword(){
        if(text.text.Length == 6 && numberOfWord == Code){
            text.color = Color.green;
            text.text = "Correct";
            hiddenDoor.SetActive(false);
            Invoke("Delete", 1);
        }
        else if(text.text.Length <= 6 && numberOfWord != Code)
        {
            Delete();
        }
    }

    private void Delete()
    {
        numberOfWord = null;
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

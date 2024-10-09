using UnityEngine;

public class Rags : MonoBehaviour
{
    private PlayerWordsManager playerWordsManager;
    public GameObject Block;
    public RagsObject rag;

    private void Awake()
    {
        playerWordsManager = FindAnyObjectByType<PlayerWordsManager>();
    }

    private void Update()
    {
        if (!rag.isTouch) return;
        playerWordsManager.MirrorPuzzleText();
        Block.SetActive(false);
        gameObject.SetActive(false);
    }
}

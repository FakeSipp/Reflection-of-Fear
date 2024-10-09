using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [Header("Box Puzzle")]
    public GameObject candleUI;
    public BoxPuzzle box;

    [Header("Computer Puzzle")]
    public GameObject computerUI;
    public ComputerPuzzle computer;

    void Update()
    {
        BoxPuzzleUIHandle();
        ComputerPuzzleUIHandle();
    }
    private void ComputerPuzzleUIHandle()
    {
        if (computerUI != null)
        {
            if (computer.isTouch)
            {
                computerUI.SetActive(true);
            }
        }
    }

    private void BoxPuzzleUIHandle()
    {
        if (box != null)
        {
            if (box.isTouch)
            {
                candleUI.SetActive(true);
            }
        }
    }
}

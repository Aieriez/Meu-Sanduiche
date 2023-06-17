using UnityEngine;
using TMPro;

public class GameStarter : MonoBehaviour
{
    void GameStart()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "3";
        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        GameManager.instance.startGame = true;
        GameManager.instance.ChooseRandomSandwich();
    }   
}

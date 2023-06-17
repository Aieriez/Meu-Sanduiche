using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI ptsText, recipeText, sandwichNameText, endPtsNum;
    public SpriteRenderer ingredient1, ingredient2,ingredient3;
    GameObject btns;
    [SerializeField] Button[] buttons;
    [SerializeField] Button replayBtn;
    public Animator endPanel;
    void Awake()
	{
        if (instance == null)
        {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
        else 
        {
			Destroy (gameObject);
		}
        
        SceneManager.sceneLoaded += Load;
        
    }

    void Load (Scene scene, LoadSceneMode mode)
    {
        UILoad();
    }

    private void UILoad()
    {
        ptsText = GameObject.Find("PtsText").GetComponent<TextMeshProUGUI>();
        recipeText = GameObject.Find("RecipeText").GetComponent<TextMeshProUGUI>();
        sandwichNameText = GameObject.Find("SandwichName").GetComponent<TextMeshProUGUI>();
        endPtsNum = GameObject.Find("End PtsNum").GetComponent<TextMeshProUGUI>();
        endPanel =  GameObject.Find("EndPanel").GetComponent<Animator>();
        replayBtn = GameObject.Find("BtnReplay").GetComponent<Button>();
        ingredient1 = GameObject.Find("Ingredient1").GetComponent<SpriteRenderer>();
        ingredient2 = GameObject.Find("Ingredient2").GetComponent<SpriteRenderer>();
        ingredient3 = GameObject.Find("Ingredient3").GetComponent<SpriteRenderer>();
        btns = GameObject.FindWithTag("BtnIngredients");
        buttons = btns.GetComponentsInChildren<Button>();
              
        replayBtn.onClick.AddListener(() => Replay());
    }

    void Update() 
    {
        if(GameManager.instance.selectedCount == 0 && GameManager.instance.startGame)
        {
            foreach (Button btn in buttons)
            {
                btn.interactable = true;
            }   
        }
        if (GameManager.instance.endGame)
        {
            foreach (Button btn in buttons)
            {
                btn.interactable = false;
            }
        }    
    }

    void Replay()
    {
        GameManager.instance.endGame = false;
        SceneManager.LoadScene("MySandwiches");
    }
}

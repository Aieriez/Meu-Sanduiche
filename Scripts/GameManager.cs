using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] SandwichData[] sandwichData;
    [SerializeField] SandwichData sandwich;
    [SerializeField] SandwichPrefab preview;
    [SerializeField] string[] recipe;
    [SerializeField] int pts; 
    public List<string> ingredients = new List<string>();
    public int selectedCount;
    [SerializeField] bool checkIngredients = false;
    public bool startGame, endGame;    

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
        
	}
    void Start()
    {
        selectedCount = 0;
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (pts < 0)
        {
                pts = 0;
                UIManager.instance.ptsText.text = pts.ToString();
        }
        if(endGame)
        {
            UIManager.instance.endPanel.Play("EndPanel");
            UIManager.instance.endPtsNum.text = pts.ToString();
            selectedCount = 0;
            startGame = false;
        }
        else
        {
            CheckIngredientsIngredients();
        }
    }

    void CheckIngredientsIngredients()
    {
        if(selectedCount == 3)
        {   
            for (int i = 0; i < recipe.Length; i++)
            {
                checkIngredients = ingredients[i] == recipe[i];    
            }
            if(checkIngredients)
            {
                pts += 100;
                UIManager.instance.ptsText.text = pts.ToString();
                checkIngredients = false;
                ClearPlate();
            }
            else
            {
                pts -= 50;
                UIManager.instance.ptsText.text = pts.ToString();
                ClearPlate();
            } 
            selectedCount = 0;
        }
    }

    public void ChooseRandomSandwich()
    {
        sandwich = sandwichData[UnityEngine.Random.Range(0, sandwichData.Length)];
        preview.sandwichData = sandwich;
        preview.AssembleSandwich();
        recipe = sandwich.ingredients;
        UIManager.instance.sandwichNameText.text = sandwich.name;
        UIManager.instance.recipeText.text = "Receita\n";
        foreach (var item in recipe)
        {
            UIManager.instance.recipeText.text += item + ", " ;  
        }
    }

    void ClearPlate()
    {
        UIManager.instance.ingredient1.sprite = null;
        UIManager.instance.ingredient2.sprite = null;
        UIManager.instance.ingredient3.sprite = null;
            
        ingredients.Clear();
        ChooseRandomSandwich();
    }

}

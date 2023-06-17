using UnityEngine;

public class SandwichPrefab : MonoBehaviour
{
    public string sandwichName;
    [SerializeField] SpriteRenderer[] sandwichesIngredients;
    [SerializeField] string[] recipe;
    public SandwichData sandwichData;

    void Awake() 
    {
        sandwichesIngredients = GetComponentsInChildren<SpriteRenderer>();    
    }
    
    public void AssembleSandwich()
    {
        sandwichName = sandwichData.name;
        recipe = sandwichData.ingredients;

        for (int i = 0; i < sandwichData.sprites.Length; i++)
        {
            sandwichesIngredients[i].sprite = sandwichData.sprites[i];  
        }
    }
}

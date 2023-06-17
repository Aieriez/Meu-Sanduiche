using UnityEngine;
using UnityEngine.UI;

public class BtnIngredient : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] string ingredientName;
    [SerializeField] Button button;
    [SerializeField] GameObject[] spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ingredientName = name.Split('_')[1];
        button = this.GetComponent<Button>();
        image = this.GetComponent<Image>();
        spriteRenderer = GameObject.FindGameObjectsWithTag("Ingredients");
        button.onClick.AddListener(() => PutIngredient());
        
    }

    void PutIngredient()
    {
        button.interactable = false;
        foreach (var item in spriteRenderer)
        {
            if(item.GetComponent<SpriteRenderer>().sprite == null)
            {
                item.GetComponent<SpriteRenderer>().sprite = image.sprite;
                GameManager.instance.ingredients.Add(ingredientName);
                GameManager.instance.selectedCount++;
                break;
            }
        }
    }
}

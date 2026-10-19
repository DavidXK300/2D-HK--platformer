using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image[] uiimage;
    public Sprite fullheart;
    public Sprite emptyheart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int health)
    {
        Debug.Log("HealthUI received: " + health);
        for (int i = 0; i < uiimage.Length; i++)
        {
            if(i < health)
            {
                uiimage[i].sprite = fullheart;
            }
            else
            {
                uiimage[i].sprite = emptyheart;
            }
        }
    }
}

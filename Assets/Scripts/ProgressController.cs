using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
    public Image image;
    public CatSenses catSenses;

    private Dictionary<CatSenses.Level, float> innerBarSizeDictionary = new Dictionary<CatSenses.Level, float>();
    private float xBasePosition;
    private RectTransform imageTransform;

    // Start is called before the first frame update
    void Start()
    {
        imageTransform = image.GetComponent<RectTransform>();

        innerBarSizeDictionary.Add(CatSenses.Level.Low, 10f);
        innerBarSizeDictionary.Add(CatSenses.Level.Medium, 60f);
        innerBarSizeDictionary.Add(CatSenses.Level.High, 120f);

        catSenses.proximityToExitPercentage = 10f;
        xBasePosition = image.GetComponent<RectTransform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        float width = catSenses.proximityToExitPercentage * 1.2f;
        float newX = xBasePosition + (width * imageTransform.localScale.x * 0.4f);
        float newY = imageTransform.position.y;

        imageTransform.sizeDelta = new Vector2(width, imageTransform.sizeDelta.y);
        imageTransform.position = new Vector3(newX, newY);
    }
}

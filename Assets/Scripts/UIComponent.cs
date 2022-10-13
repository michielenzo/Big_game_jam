using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    public GameObject exitObject;
    public CatSenses catSenses;

    private float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = Vector3.Distance(transform.position, exitObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, exitObject.transform.position);

        if (distance < 0)
        {
            distance = distance * -1f;
        }
        if (distance > maxDistance)
        {
            distance = maxDistance;
        }

        float percentage = (distance / maxDistance) * 100f;
        percentage = 100 - percentage;

        catSenses.proximityToExitPercentage = percentage;
    }
}

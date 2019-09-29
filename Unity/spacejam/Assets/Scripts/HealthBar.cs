using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public GameObject barSprite;
    public Destruction planet;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
    }

    private void Update()
    {
        //barSprite.GetComponent<RectTransform>(). = planet.health / 25.0f;
        SetSize((planet.health / 25.0f) * 0.65f);
    }

    public void SetSize (float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
     }
}

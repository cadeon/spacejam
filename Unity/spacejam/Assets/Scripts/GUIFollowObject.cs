using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUIFollowObject : MonoBehaviour
{
    public string displayName;
    public Text labelObject;
    Text textLabel;

    private void Start()
    {
        textLabel = Instantiate(labelObject, FindObjectOfType<Canvas>().transform);
        textLabel.text = displayName;
        textLabel.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    void Update()
    {
        textLabel.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnDestroy()
    {
        if (textLabel)
        {
            Destroy(textLabel.gameObject);
        }
    }
}

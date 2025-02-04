using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Memory of Pain Complete") == 1 && PlayerPrefs.GetInt("Memory of Growth Complete") == 1 && PlayerPrefs.GetInt("Memory of Love Complete") == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

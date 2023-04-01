using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsCreator : MonoBehaviour
{
    void Start()
    {
        GameObject prefab = transform.GetChild(0).gameObject;
        prefab.SetActive(false);

        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            GameObject temp = Instantiate(prefab, transform);
            //temp.transform.SetParent(transform);
            int buildIndex = i;
            temp.GetComponent<Button>().onClick.AddListener(delegate (){ SceneManager.LoadScene(buildIndex);});
            temp.GetComponentInChildren<TMP_Text>().text = $"Level {buildIndex}";
            temp.SetActive(true);
        }
    }
}

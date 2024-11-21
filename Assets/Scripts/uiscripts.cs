using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiscripts : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class ButtonHandler : MonoBehaviour
    {
        public void back()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
      
}

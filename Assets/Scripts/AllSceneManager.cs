using UnityEngine;

public class AllSceneManager : MonoBehaviour
{
    void Update()
    {
        // Pキーでタイトル
        if (Input.GetKeyDown(KeyCode.P))
        {
            Transition transition = GameObject.FindWithTag("Transition").GetComponent<Transition>();

            if (!transition.GetIsTransitionNow())
            {
                transition.SetTransition("TitleScene");
            }
        }

        // ウィンドウを閉じる
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

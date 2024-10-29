using UnityEngine;

public class AllSceneManager : MonoBehaviour
{
    void Update()
    {
        // P�L�[�Ń^�C�g��
        if (Input.GetKeyDown(KeyCode.P))
        {
            Transition transition = GameObject.FindWithTag("Transition").GetComponent<Transition>();

            if (!transition.GetIsTransitionNow())
            {
                transition.SetTransition("TitleScene");
            }
        }

        // �E�B���h�E�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

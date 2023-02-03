using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadBtn : MonoBehaviour
{
   public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}

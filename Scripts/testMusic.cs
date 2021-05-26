using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class testMusic : MonoBehaviour
{
    private static testMusic instance = null;
    public static testMusic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);//使对象目标在加载新场景时不被自动销毁。
    }
    public void onChangeSceneButtonClicked()
    {
        changeScene("SettingPage");
    }
    //切换场景
    public void changeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);//切换到场景Scene2
    }
}
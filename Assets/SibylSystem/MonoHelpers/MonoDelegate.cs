using UnityEngine;
using System;
using System.Collections;
using System.IO;
public class MonoDelegate : MonoBehaviour
{
    public Action actionInMono;
    public void function()
    {
        if (actionInMono != null) actionInMono();
    }
}


public class MonoListener : MonoBehaviour
{
    public Action<GameObject> actionInMono;
    public void function()
    {
        if (actionInMono != null) actionInMono(this.gameObject);
    }
}

public class MonoListenerRMS_ized : MonoBehaviour
{
    public Action<GameObject, Servant.messageSystemValue> actionInMono;
    public Servant.messageSystemValue value;
    public void function()
    {
        UIInput input = GetComponent<UIInput>();
        if (input != null)
        {
            value = new Servant.messageSystemValue();
            value.hint = input.name;
            value.value = input.value;
        }
        if (actionInMono != null) actionInMono(this.gameObject, value);
    }
}

public class MonoScript : MonoBehaviour
{
    void Start()
    {
        NonMonoScript nonMonoScript = new NonMonoScript();
        //Pass MonoBehaviour to non MonoBehaviour class
        nonMonoScript.monoParser(this);
    }
}
public class NonMonoScript
{
    public void monoParser(MonoBehaviour mono)
    {
        //We can now use StartCoroutine from MonoBehaviour in a non MonoBehaviour script
        mono.StartCoroutine(testFunction());

        //And also use StopCoroutine function
        mono.StopCoroutine(testFunction());
    }

    IEnumerator testFunction()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Test!");
    }
}
public class MonoDownload : MonoBehaviour
{
    private string url;
    private string targetFile;
    bool isDone;
    public bool IsDone()
    {
        return isDone;
    }
    public MonoDownload(string url, string targetFile)
    {
        this.url = url;
        this.targetFile = targetFile;
        start();
    }
    void start()
    {
        StartCoroutine(Download());
    }
    IEnumerator Download()
    {
        isDone = false;
        WWW request = new WWW(url);
        while (!request.isDone)
            yield return null;
        isDone = true;
        File.WriteAllBytes(targetFile, request.bytes);
    }
}
public class MonoDownloader : MonoBehaviour
{
    public event EventHandler DownloadForCloseUpCompleted;
    /// <summary>Occurs when [card download is completed].</summary>
    public event EventHandler DownloadCardCompleted;
    /// <summary>Occurs when [closeup download is completed].</summary>
    public event EventHandler DownloadCloseupCompleted;
    public void start(string url, string targetFile)
    {
        StartCoroutine(Download(url, targetFile));
    }
    IEnumerator Download(string url, string targetFile)
    {
        WWW request = new WWW(url);
        while (!request.isDone)
            yield return null;
        File.WriteAllBytes(targetFile, request.bytes);
        if (DownloadCardCompleted != null)
        {
            DownloadCardCompleted(this, null);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Reflection;
using UnityEngine.SceneManagement;

public enum eLoadingState
{
    None,
    Unload,
    GotoScene,
    Done
}

public class UILoading : MonoBehaviour
{
    private AsyncOperation _unloadDone, _loadLevelDone;

    private eLoadingState _myState;

    private StringBuilder _sb;

    private float _timeLimit;

    const string MainSceneStr = "MainScene";

    private void Awake() 
    {
        _sb = new StringBuilder();    
    }

    private void Start() 
    {
        _myState = eLoadingState.None; 
        NextState();   
    }

    IEnumerator NoneState()
    {
        // 로딩의 최초 시작지점에 초기화 해주는 코딩

        _myState = eLoadingState.Unload;

        while(_myState == eLoadingState.None)
        {
            yield return null;
        }

        NextState();
    }

    IEnumerator UnloadState()
    {
        _unloadDone = Resources.UnloadUnusedAssets();
        System.GC.Collect();

        while(_myState == eLoadingState.Unload)
        {
            if(_unloadDone.isDone)
            {
                _myState = eLoadingState.GotoScene;
            }

            yield return null;
        }

        NextState();
    }

    IEnumerator GotoSceneState()
    {
        _loadLevelDone = SceneManager.LoadSceneAsync(MainSceneStr);

        // 최소한 3초 이상은 로딩되도록
        _timeLimit = 3.0f;

        while(_myState == eLoadingState.GotoScene)
        {
            _timeLimit -= Time.deltaTime;
            if(_loadLevelDone.isDone && _timeLimit <= 0f)
            {
                _myState = eLoadingState.Done;
            }

            yield return null;
        }

        NextState();
    }

    IEnumerator DoneState()
    {
        MGScene.Instance.LoadingDone();

        while(_myState == eLoadingState.Done)
        {
            yield return null;
        }
    }

    void NextState()
    {
        _sb.Remove(0, _sb.Length);
        _sb.Append(_myState.ToString());
        _sb.Append("State");

        MethodInfo mInfo = this.GetType().GetMethod(_sb.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        StartCoroutine((IEnumerator)mInfo.Invoke(this, null));
    }
}

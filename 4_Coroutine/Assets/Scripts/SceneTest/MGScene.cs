using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    싱글톤 클래스
*/

public enum eSceneName
{
    None = -1,
    Loading,    // 로딩
    Logo,       // 로고
    Title,      // 타이틀
    Game        // 게임
}

public class MGScene : MonoBehaviour
{
    private static MGScene _instance;
    public static MGScene Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(MGScene)) as MGScene;
                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<MGScene>();
                }
            }

            return _instance;
        }
    }

    private StringBuilder _sb;
    private eSceneName _curScene, _beforeScene;
    private Transform  _uiRootTrm;      // 모든 UI의 기초가 되는 캔버스
    private Transform _addUITrm;        // root 밑에 추가되는 각 씬과 일대일로 매칭되는 UI

    public GameObject _uiRootPrefab;

    public GameObject _loadinguiPrefab;
    public GameObject _logoUiPrefab;
    public GameObject _titleUiPrefab;
    public GameObject _gameUiPrefab;

    public void Generate(){}            // 생성하는 용도

    private void Awake() 
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _sb = new StringBuilder();

        GameObject uiRootObj = GameObject.Instantiate(_uiRootPrefab) as GameObject;
        _uiRootTrm = uiRootObj.transform;

        InitScene();
    }

    void InitScene()
    {
        // 최초로 화면에 보여줄 화면
        ChangeScene(eSceneName.Logo);
    }

    public void ChangeScene(eSceneName inScene)
    {
        _beforeScene = _curScene;
        _curScene = inScene;

        _sb.Remove(0, _sb.Length);
        _sb.AppendFormat("{0}Scene", eSceneName.Loading);

        SceneManager.LoadScene(_sb.ToString());

        ChangeUI(eSceneName.Loading);
    }

    void ChangeUI(eSceneName inScene)
    {
        // 기존 ui 프리팹은 삭제
        if(_addUITrm != null)
        {
            _addUITrm.SetParent(null);
            GameObject.Destroy(_addUITrm.gameObject);
        }

        // eScenename과 일대일로 매칭되는 ui들을 로드 해준다.
        // 하드코딩
        GameObject go = null;

        if(inScene == eSceneName.Loading)
            go = GameObject.Instantiate(_loadinguiPrefab) as GameObject;
        else if(inScene == eSceneName.Logo)
            go = GameObject.Instantiate(_logoUiPrefab) as GameObject;
        else if(inScene == eSceneName.Title)
            go = GameObject.Instantiate(_titleUiPrefab) as GameObject;
        else if(inScene == eSceneName.Game)
            go = GameObject.Instantiate(_gameUiPrefab) as GameObject;

        _addUITrm = go.transform;
        _addUITrm.SetParent(_uiRootTrm);

        _addUITrm.localPosition = Vector3.zero;
        _addUITrm.localScale = new Vector3(1, 1, 1);

        RectTransform rts = go.GetComponent<RectTransform>();
        rts.offsetMax = new Vector2(0, 0);
        rts.offsetMin = new Vector2(0, 0);
    }

    public void LoadingDone()
    {
        ChangeUI(_curScene);
        Debug.Log("로딩 끝");
    }
}

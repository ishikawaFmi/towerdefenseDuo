using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    static public StageSelect Incetance;

    public Subject<Stage> StageSelectSubject = new Subject<Stage>();

    [SerializeField] GameObject _stageUiPrefab;

    [SerializeField] GameObject _stageUi;

    int _page = 1;

    void Awake()
    {
        if (Incetance == null)
        {
            Incetance = this;
        }
    }

    void Start()
    {
        StageSelectSubject.Subscribe(stage => GameManager.Incetance.CurrentStage = stage);
        StageSelectSubject.Subscribe(_ => SceneManager.LoadScene("Game"));

        StageSelectUiSetup();
    }

    void StageSelectUiSetup()
    {
        UiInit(_stageUi);

        for (int i = _page * 4 - 4; i < _page * 4; i++)
        {
            if (StageManager.Incetance.StageList.Count > i&& StageManager.Incetance.StageList.Count > 0)
            {
                var stageUi = Instantiate(_stageUiPrefab, _stageUi.transform);

                SetStageUi(stageUi, StageManager.Incetance.StageList[i]);
            } 
        }
    }

    void SetStageUi(GameObject stageUi, Stage stage)
    {

        for (int i = 0; i < stageUi.transform.childCount; i++)
        {
            var child = stageUi.transform.GetChild(i);

            switch (child.name)
            {
                case "StageName":
                    child.GetComponent<Text>().text = stage.StageName;
                    break;
                case "StageSelectButton":
                    child.GetComponent<Button>().onClick.AddListener(() => StageSelectSubject.OnNext(stage));
                    break;
                default:
                    break;
            }
        }
    }

    void UiInit(GameObject gameObject)
    {
        foreach (Transform x in gameObject.transform)
        {
            Destroy(x.gameObject);
        }
    }
}

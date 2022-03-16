using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StageCustomWindow : EditorWindow
{
    Vector2 _dataListPos;
    Vector2 _parameterPos;

    List<Stage> _stageList = new List<Stage>();
    Stage _selectStage;

    string _stageName;

    [MenuItem("Editor/Stage")]
    public static void ShouWindow()
    {
        EditorWindow.GetWindow(typeof(StageCustomWindow));
    }
    private void OnEnable()
    {
        Stage[] stages = Resources.LoadAll<Stage>("StageData");

        foreach (var status in stages)
        {
            _stageList.Add(status);
        }
    }
    private void OnGUI()
    {
        GUILayout.Label("Stage", EditorStyles.boldLabel);

        using (new GUILayout.HorizontalScope())
        {
            UpdateLayoutData();
            UpdateLayoutParameter();
        }

    }

    void UpdateLayoutData()
    {
        using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_dataListPos, EditorStyles.helpBox, GUILayout.Width(150)))
        {
            _dataListPos = scroll.scrollPosition;

            GUILayout.Label("Data");

            _stageName = GUILayout.TextField(_stageName);
            if (GUILayout.Button("Stageを作成する"))
            {
                _stageList.Add(CreateInstance<Stage>());
                _selectStage = _stageList[_stageList.Count - 1];
                AssetDatabase.CreateAsset(_selectStage, $"Assets/Resources/StageData/{_stageName}.asset");
                _selectStage.StageName = _stageName;
                _stageName = null;
            }

            for (int i = 0; i < _stageList.Count; i++)
            {
                GUI.backgroundColor = (_stageList[i] == _selectStage ? Color.cyan : Color.white);
                if (GUILayout.Button($"{_stageList[i].StageName}:Stage"))
                {
                    _selectStage = _stageList[i];
                }

                GUI.backgroundColor = Color.white;
            }
        }
    }

    void UpdateLayoutParameter()
    {
        using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_parameterPos, EditorStyles.helpBox))
        {
            _parameterPos = scroll.scrollPosition;
            GUILayout.Label("Patameter");

            if (_selectStage)
            {
                Editor.CreateEditor(_selectStage).DrawDefaultInspector();

                if (GUILayout.Button("Stageを削除する"))
                {
                    AssetDatabase.DeleteAsset($"Assets/Resources/StageData/{_selectStage.name}.asset");
                    _stageList.Remove(_selectStage);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Status))]
public class StatusWindow : EditorWindow
{
    Vector2 _dataListPos;
    Vector2 _parameterPos;

    List<Status> _statusList = new List<Status>();
    Status _selectStatus;

    string _statusName;

    [MenuItem("Editor/Status")]
    public static void ShouWindow()
    {
        EditorWindow.GetWindow(typeof(StatusWindow));
    }

    private void OnEnable()
    {
        Status[] statuses = Resources.LoadAll<Status>("StatusData");

        foreach (var status in statuses)
        {
            _statusList.Add(status);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Status", EditorStyles.boldLabel);       

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

            _statusName = GUILayout.TextField(_statusName);
            if (GUILayout.Button("Statusを作成する"))
            {
                _statusList.Add(CreateInstance<Status>());
                _selectStatus = _statusList[_statusList.Count - 1];
                AssetDatabase.CreateAsset(_selectStatus, $"Assets/Resources/StatusData/{_statusName}.asset");
                _selectStatus.CharacterName = _statusName;
                _statusName = null;
            }

            for (int i = 0; i < _statusList.Count; i++)
            {
                GUI.backgroundColor = (_statusList[i] == _selectStatus ? Color.cyan : Color.white);
                if (GUILayout.Button($"{_statusList[i].CharacterName}:Status"))
                {
                    _selectStatus = _statusList[i];
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

            if (_selectStatus)
            {
                Editor.CreateEditor(_selectStatus).DrawDefaultInspector();

                if (GUILayout.Button("Statusを削除する"))
                {
                    AssetDatabase.DeleteAsset($"Assets/Resources/StatusData/{_selectStatus.name}.asset");
                    _statusList.Remove(_selectStatus);
                }
            }
        }
    }
}

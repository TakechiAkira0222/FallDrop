using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;

namespace Takechi.EditorMenu.SceneChange
{
    public class ChangeTheProductionScene : EditorWindow
    {
        private const string menuBarName     = "MyEditorSetting/SceneSwitching/";
        private const string scenesFolderPas = "Assets/Scenes/";

        #region private
        private int selectBeforeShaderIndex;
        #endregion

        [MenuItem("MyEditorSetting/ChangeTheProductionScene _#F1", false, 500)]
        private static void Open()
        {
            GetWindow<ChangeTheProductionScene>();
        }

        #regionÅ@UnityEvent

        private void OnGUI()
        {
            List<string> pathList = new List<string>();

            foreach (var guid in AssetDatabase.FindAssets("t:Scene", new string[] { scenesFolderPas }))
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                pathList.Add(path);
            }

            selectBeforeShaderIndex =
                EditorGUILayout.Popup("selectScene", selectBeforeShaderIndex, pathList.ToArray());

            if (GUILayout.Button("OnOpenScene"))
            {
                EditorSceneManager.OpenScene(pathList[selectBeforeShaderIndex], OpenSceneMode.Single);
            }
        }

        #endregion

        //[MenuItem( menuBarName + " TitleScnene _#F1")]
        //private static void SceneSwitchingSceneTitleScnene()
        //{
        //    EditorSceneManager.OpenScene(scenesFolderPas + "/TitleScneneFolder/" + "TitleScnene.unity", OpenSceneMode.Single);
        //}
        //[MenuItem( menuBarName + " LobbyScene _#F2")]
        //private static void SceneSwitchingSceneLobbyScene()
        //{
        //    EditorSceneManager.OpenScene(scenesFolderPas + "/LobbySceneFolder/" + "LobbyScene.unity", OpenSceneMode.Single);
        //}
    }
}
#endif

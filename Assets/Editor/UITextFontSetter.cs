using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Modules.Util
{
    public class UITextFontSetter
    {
        // 폰트 경로 지정
        public const string PATH_FONT_TEXTMESHPRO_NEO = "Assets/TextMesh Pro/Fonts/neodgm SDF.asset";

        [MenuItem("Tools/전체 폰트 변경")]
        public static void ChangeFontInTexMeshPro()
        {
            GameObject[] rootObj = GetSceneRootObjects();

            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = rootObj[i];
                TextMeshProUGUI[] texts = gbj.GetComponentsInChildren<TextMeshProUGUI>(true);

                foreach (TextMeshProUGUI txt in texts)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(PATH_FONT_TEXTMESHPRO_NEO);
                    // 폰트 색 변경 예시
                    // txt.color = Color.black;
                }
            }
        }

        /// <summary>
        /// 모든 최상위 Root의 GameObject를 받아옴
        /// </summary>
        private static GameObject[] GetSceneRootObjects()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            return currentScene.GetRootGameObjects();
        }
    }
}

using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Modules.Util
{
    public class UITextFontSetter
    {
        /*
        // 폰트 경로 지정
        // public const string PATH_FONT_TEXTMESHPRO_MALGUNBD = "Assets/TextMesh Pro/Fonts/TMoneyRoundWindExtraBold SDF.asset";

        [MenuItem("전체 폰트 변경")]
        public static void ChangeFontInTexMeshPro()
        {
            GameObject[] rootObj = GetSceneRootObjects();

            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = (GameObject)rootObj[i] as GameObject;
                Component[] com = gbj.transform.GetComponentsInChildren(typeof(TextMeshProUGUI), true);
                foreach (TextMeshProUGUI txt in com)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(PATH_FONT_TEXTMESHPRO_MALGUNBD);
                    // 폰트 색 변경
                    // txt.color = Color.black;
                }
            }
        }

        /// <summary>
        /// 모든 최상위 Root의 GameObject를 받아옴
        /// </summary>
        /// <returns></returns>
        private static GameObject[] GetSceneRootObjects()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            return currentScene.GetRootGameObjects();
        }
        */
    }
}

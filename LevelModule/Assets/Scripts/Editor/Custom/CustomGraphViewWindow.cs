using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CustomGraphViewWindow:BaseGraphWindow
{
        protected override GUIContent Title => new GUIContent("自定义节点图表");

        protected override void OnEnable()
        {
                base.OnEnable();
                if (this.m_BaseGraph == null)
                {
                        this.InitGraph(ScriptableObject.CreateInstance<BaseGraph>());
                }
        }

        protected override void InitWindow()
        {
                if (this.m_BaseGraph == null)
                {
                        this.m_BaseGraphView = new BaseGraphView(this);
                }
                this.m_RootVisualElement.Add(this.m_BaseGraphView);
        }

        [MenuItem("Window/打开自定义图标")]
        internal static void OpenCustomGraphViewWindow()
        {
                CustomGraphViewWindow customGraphViewWindow = EditorWindow.GetWindow<CustomGraphViewWindow>();
                customGraphViewWindow.Show();
        }
}        
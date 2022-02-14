using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseGraphWindow : EditorWindow
{

    protected virtual GUIContent Title => new GUIContent("BaseGraphWindow");

    protected VisualElement m_RootVisualElement = null;
    protected BaseGraphView m_BaseGraphView = null;
    protected BaseGraph m_BaseGraph = null;

    protected virtual void OnEnable()
    {
        this.titleContent = this.Title;
        this.InitRootView();
    }

    protected virtual void InitRootView()
    {
        this.m_RootVisualElement = this.rootVisualElement;
    }
    
    //初始化图表
    protected virtual void InitGraph(BaseGraph _baseGraph)
    {
        this.m_BaseGraph = _baseGraph;
        this.InitWindow();
    }
    //初始化窗口
    protected virtual void InitWindow()
    {
        
    }
}

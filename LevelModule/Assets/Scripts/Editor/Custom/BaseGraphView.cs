using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class BaseGraphView : GraphView
{
    private BaseGraphWindow m_BaseGraphWindow = null;

    
    public BaseGraphView(BaseGraphWindow _baseGraphWindow)
    {
        this.m_BaseGraphWindow = _baseGraphWindow;
        this.InitManipulators();
        this.AddGridBackground();
        
        //缩放限制
        this.SetupZoom(0.05f,2.0f);
        this.StretchToParentSize();
    }
    //初始化操作器
    protected virtual void InitManipulators()
    {
        
    }
    //绘制网格
    protected virtual void AddGridBackground()
    {
        GridBackground background = new GridBackground();
        //插入元素（有父节点）
        this.Insert(0,background);
        //大小适配
        background.StretchToParentSize();
    }
}
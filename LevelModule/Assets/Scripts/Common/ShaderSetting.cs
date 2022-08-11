using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using GameDemo.FSM;
using GameDemo.Character;
public class ShaderSetting : MonoBehaviour
{
    public float blinkTime;
    public float blackTime;
    public float coverTime;

    public List<Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GetComponentInChildren<Transform>().GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            materials.Add(item.material);
        }
        materials = ArrayHelper.FindAll_L<Material>(materials, t => t.shader.name == "Shader Graphs/LitPokemonShader");

        //StartCoroutine(blinkTime_Coroutine());
        EventManager.Instance.AddEventListener<FSMBase>("����˺�", Blink);
    }

    private void OnEnable()
    {
        //StartCoroutine(blinkTime_Coroutine());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Blink(FSMBase fsm) 
    {
        StartCoroutine(blinkTime_Coroutine());
    }

    void Black()
    {

    }

    void CoverPar()
    {

    }

    public IEnumerator blinkTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_148bed11a38b41a5b92404c3d3378974", Color.Lerp(new Color(0, 0, 0, 1), new Color(1, 1, 1, 1), Time.deltaTime * blinkTime));
        }
        
      /*  foreach (var item in materials)
        {
            item.SetColor("Color_1c0cb89cf1a94bb38394531b7d9b1fc5", Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), Time.deltaTime * blackTime));
        }
        foreach (var item in materials)
        {
            item.SetColor("Color_148bed11a38b41a5b92404c3d3378974", Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), Time.deltaTime * blackTime));
            item.SetColor("Color_1c0cb89cf1a94bb38394531b7d9b1fc5", Color.Lerp(new Color(0, 0, 0, 1), new Color(1, 1, 1, 1), Time.deltaTime * blackTime));
        }*/
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(blackTime_Coroutine());
    }
    public IEnumerator blackTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_1c0cb89cf1a94bb38394531b7d9b1fc5", Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), Time.deltaTime * blackTime));
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(CoverTime_Coroutine());
    }
    public IEnumerator CoverTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_148bed11a38b41a5b92404c3d3378974", new Color(0, 0, 0, 1));
            item.SetColor("Color_1c0cb89cf1a94bb38394531b7d9b1fc5", new Color(1, 1, 1, 1));
            /*item.SetColor("Color_148bed11a38b41a5b92404c3d3378974", Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), Time.deltaTime * coverTime));
            item.SetColor("Color_1c0cb89cf1a94bb38394531b7d9b1fc5", Color.Lerp(new Color(0, 0, 0, 1), new Color(1, 1, 1, 1), Time.deltaTime * coverTime));*/
        }
        yield return new WaitForSeconds(0.05f);
    }
}

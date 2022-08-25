using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using GameDemo.FSM;
using GameDemo.Character;
using GameDemo.Skill;
using GameDemo.Event;
public class ShaderSetting : MonoSingleton<ShaderSetting>
{
    public float blinkTime;
    public float blackTime;
    public float coverTime;

    public List<Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener<GameObject, Transform, SkillData>(EventType.Event_Damage, M_Blink);
    }
    public void M_Blink(GameObject self, Transform target, SkillData data) 
    {
        foreach (var item in target.GetComponentInChildren<Transform>().GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            materials.Add(item.material);
        }
        materials = ArrayHelper.FindAll_L<Material>(materials, t => t.shader.name == "Shader Graphs/LitPokemonShader");
        StartCoroutine(blinkTime_Coroutine());
    }

    public IEnumerator blinkTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_ADD", Color.Lerp(new Color(0, 0, 0, 1), new Color(1, 1, 1, 1), Time.deltaTime * blinkTime));
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(blackTime_Coroutine());
    }
    public IEnumerator blackTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_MUL", Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 1), Time.deltaTime * blackTime));
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(CoverTime_Coroutine());
    }
    public IEnumerator CoverTime_Coroutine()
    {
        foreach (var item in materials)
        {
            item.SetColor("Color_ADD", new Color(0, 0, 0, 1));
            item.SetColor("Color_MUL", new Color(1, 1, 1, 1));
        }
        materials.Clear();
        yield return new WaitForSeconds(0.05f);
    }

    public void M_ChangeState(CharacterStatus characterStatus)
    {
        foreach (var item in characterStatus.GetComponentInChildren<Transform>().GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            materials.Add(item.material);
        }
        materials = ArrayHelper.FindAll_L<Material>(materials, t => t.shader.name == "Shader Graphs/LitPokemonShader");
        foreach (var item in materials)
        {
            
            item.SetFloat("Fresnel1",0.3f);
            item.SetFloat("Fresnel2",0.3f);
            item.SetFloat("FresnelSW",1f);
        }
    }
    public void M_InitState(CharacterStatus characterStatus)
    {
        foreach (var item in characterStatus.GetComponentInChildren<Transform>().GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            materials.Add(item.material);
        }
        materials = ArrayHelper.FindAll_L<Material>(materials, t => t.shader.name == "Shader Graphs/LitPokemonShader");
        foreach (var item in materials)
        {
            
            item.SetFloat("Fresnel1",0f);
            item.SetFloat("Fresnel2",0f);
            item.SetFloat("FresnelSW",0f);
        }
    }
}

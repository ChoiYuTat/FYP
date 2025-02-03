Shader"Universal Render Pipeline/Custom/DistanceTransparency"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white" {}
        _MaxDistance("Max Distance", Float) = 2.0
        _MinAlpha("Minimum Alpha", Range(0,1)) = 0.3
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
        }

Blend SrcAlpha
OneMinusSrcAlpha
        ZWriteOff

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

struct appdata
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
    float3 worldPos : TEXCOORD1;
};

            CBUFFER_START(UnityPerMaterial)
float4 _MainTex_ST;
half4 _BaseColor;
float _MaxDistance;
float _MinAlpha;
CBUFFER_END

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

v2f vert(appdata v)
{
    v2f o;
    o.vertex = TransformObjectToHClip(v.vertex.xyz);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
    o.worldPos = TransformObjectToWorld(v.vertex.xyz);
    return o;
}

half4 frag(v2f i) : SV_Target
{
                // 计算与摄像机的距离
    float3 cameraPos = _WorldSpaceCameraPos;
    float distanceToCamera = distance(i.worldPos, cameraPos);
                
                // 根据距离插值透明度
    float alpha = lerp(_MinAlpha, 1.0, saturate(distanceToCamera / _MaxDistance));
                
    half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
    col *= _BaseColor;
    col.a *= alpha;
    return col;
}
            ENDHLSL
        }
    }
}
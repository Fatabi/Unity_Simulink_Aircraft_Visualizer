Shader "Custom/TerrainShader"
{
    Properties
    {
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        
        sampler2D terrainGradient;
        float minTerrainHeight;
        float maxTerrainHeight;
        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

 


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float3 worldPosY = IN.worldPos.y;
            float heightValue = saturate((worldPosY - minTerrainHeight)/(maxTerrainHeight - minTerrainHeight));
            o.Albedo = tex2D(terrainGradient,float2(0,heightValue));
        }
        ENDCG
    }
    FallBack "Diffuse"
}

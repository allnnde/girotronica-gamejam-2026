Shader "Skybox/Day Night Panoramic"
{
    Properties
    {
        [NoScaleOffset] _DayTex ("Day Panorama", 2D) = "white" {}
        [NoScaleOffset] _NightTex ("Night Panorama", 2D) = "black" {}
        _Blend ("Day to Night", Range(0, 1)) = 0
        _Tint ("Tint", Color) = (0.5, 0.5, 0.5, 0.5)
        _Exposure ("Exposure", Range(0, 8)) = 1
        _Rotation ("Rotation", Range(0, 360)) = 0
    }
    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            #include "UnityCG.cginc"

            sampler2D _DayTex, _NightTex;
            half _Blend, _Exposure;
            half4 _Tint;
            float _Rotation;

            struct Varyings
            {
                float4 position : SV_POSITION;
                float3 direction : TEXCOORD0;
            };

            Varyings Vert(float4 vertex : POSITION)
            {
                Varyings output;
                output.direction = vertex.xyz;
                float sine, cosine;
                sincos(radians(_Rotation), sine, cosine);
                vertex.xz = mul(float2x2(cosine, -sine, sine, cosine), vertex.xz);
                output.position = UnityObjectToClipPos(vertex);
                return output;
            }

            half4 Frag(Varyings input) : SV_Target
            {
                float3 direction = normalize(input.direction);
                float2 uv = float2(
                    0.5 - atan2(direction.z, direction.x) / (2.0 * UNITY_PI),
                    0.5 + asin(clamp(direction.y, -1.0, 1.0)) / UNITY_PI);
                half3 day = tex2D(_DayTex, uv).rgb;
                half3 night = tex2D(_NightTex, uv).rgb;
                half3 sky = lerp(day, night, _Blend) * _Tint.rgb * unity_ColorSpaceDouble.rgb * _Exposure;
                return half4(sky, 1);
            }
            ENDCG
        }
    }
}

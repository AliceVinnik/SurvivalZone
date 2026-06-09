/* 
 *   ██████╗  ██████╗ ██████╗ ██████╗  ██████╗ ██████╗  ██████╗  █████╗ ███╗   ███╗███████╗███████╗
 *   ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔════╝ ██╔══██╗████╗ ████║██╔════╝██╔════╝
 *   ██████╔╝██║   ██║██████╔╝██████╔╝██║   ██║██████╔╝██║  ███╗███████║██╔████╔██║█████╗  ███████╗
 *   ██╔═══╝ ██║   ██║██╔═══╝ ██╔═══╝ ██║   ██║██╔═══╝ ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ╚════██║
 *   ██║     ╚██████╔╝██║     ██║     ╚██████╔╝██║     ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗███████║
 *   ╚═╝      ╚═════╝ ╚═╝     ╚═╝      ╚═════╝ ╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚══════╝                                                                                          
 *      Created by PopPopGames - Alice Vinnik in 2024.
 * 
 *      If you want customize or develop new game contact me. Im available to hire.
 *      👩‍💻 Website: https://poppopgames.carrd.co/
 *      📩 Email: poppopgames@proton.me
 *      
 *      Thanks for buying my games.
 *      Have a nice day!
 */

    Shader "Custom/TextureScroll"
    {
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

        _ScrollX ("Scroll X", Float) = 0.5
        _ScrollY ("Scroll Y", Float) = 0.0

        _Scale ("Texture Scale", Float) = 1.0
    }

    SubShader
    {
        Tags 
        { 
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "IgnoreProjector"="True"
            "RenderPipeline"="UniversalPipeline"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "UIForward"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            float4 _MainTex_ST;
            float4 _Color;
            float _ScrollX;
            float _ScrollY;
            float _Scale;

            v2f vert (appdata v)
            {
                v2f o;
                o.position = TransformObjectToHClip(v.vertex.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color * _Color;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                uv *= _Scale;

                uv.x += _ScrollX * _Time.y;
                uv.y += _ScrollY * _Time.y;

                uv = frac(uv);

                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
                return col * i.color;
            }

            ENDHLSL
        }
    }
    }
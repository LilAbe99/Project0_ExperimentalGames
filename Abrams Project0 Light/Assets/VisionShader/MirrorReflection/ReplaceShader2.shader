        // Replacement shader, any shader in your scene that has a matching MyTag to one of these subshaders will use the subshader defined here.
    // In this case;
    // It'll render anything with MyTag RenderWhite in red.
    // And anything with MyTag RenderBlack in green.
    // And because there isn't a subshader with MyTag RenderGrey, it won't render that material at all in this render pass.
    Shader "Custom2/ReplacementShader" {
        Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _ALightThreshold("Light Threshold", float) = 0.0
        _ALightContrast("Light Contrast", float) = 1.0
        }
        SubShader {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        LOD 200

        CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            #pragma surface surf Standard fullforwardshadows finalcolor:alphaLight alpha:fade

            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            sampler2D _MainTex;

            struct Input {
                float2 uv_MainTex;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Color;
            half _ALightThreshold;
            half _ALightContrast;

            void surf(Input IN, inout SurfaceOutputStandard o) {
                // Albedo comes from a texture tinted by color
                fixed4 c = (fixed4)1.0f;
                o.Albedo = c.rgb;
                // Metallic and smoothness come from slider variables
                o.Metallic = _Metallic;
                o.Smoothness = _Glossiness;
                o.Alpha = c.a;
            }

            void alphaLight(Input IN, SurfaceOutputStandard o, inout fixed4 color)
            {
                fixed4 c = _Color;
                color.a = 1.0f - saturate(c.a * saturate(dot(color.rgb, fixed3(1.0f, 1.0f, 1.0f) / 3.0f) - _ALightThreshold) * _ALightContrast);
                color.rgb = c.rgb;
            }

            ENDCG
        }
            FallBack "Diffuse"
    }
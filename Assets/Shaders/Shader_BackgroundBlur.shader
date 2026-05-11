Shader "Unlit/Shader_BackgroundBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 10)) = 2
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "IgnoreProjector"="True"
        }

        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _BlurSize;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 offset = _MainTex_TexelSize.xy * _BlurSize;

                fixed4 col = fixed4(0,0,0,0);

                col += tex2D(_MainTex, i.uv + offset * float2(-1, -1));
                col += tex2D(_MainTex, i.uv + offset * float2( 0, -1));
                col += tex2D(_MainTex, i.uv + offset * float2( 1, -1));

                col += tex2D(_MainTex, i.uv + offset * float2(-1,  0));
                col += tex2D(_MainTex, i.uv);
                col += tex2D(_MainTex, i.uv + offset * float2( 1,  0));

                col += tex2D(_MainTex, i.uv + offset * float2(-1,  1));
                col += tex2D(_MainTex, i.uv + offset * float2( 0,  1));
                col += tex2D(_MainTex, i.uv + offset * float2( 1,  1));

                col /= 9;
                col *= i.color;

                return col;
            }
            ENDCG
        }
    }
}

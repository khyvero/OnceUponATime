Shader "Unlit/SinkWate"
{
    Properties
    {
         _MainTex ("Texture", 2D) = "white" {}
        _Cutoff("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                
                return o;
            }

            sampler2D _MainTex;
            float _Cutoff;

            fixed4 frag (v2f i) : SV_Target
            {
                // Pen
                float2 distuv = float2(i.uv.x, i.uv.y + _Time.x *8);
                float4 color = tex2D(_MainTex, distuv);

                // Cutoff

                color.a = step(0.0, i.uv.y - _Cutoff);

                return color;
            }
            ENDCG
        }
    }
}
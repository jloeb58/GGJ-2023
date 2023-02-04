Shader "Unlit/SeedArmBlue"
{
    Properties
    {
        _ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags
        { 
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Pass
        {
            Cull Off
            ZWrite Off
            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            float4 _ColorA;
            float4 _ColorB;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            v2f vert (MeshData v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp( float a, float b, float v )
            {
                return (v-a)/(b-a);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float xOffset = cos(i.uv.x * TAU * 2) * 0.02;
                float t = cos( (i.uv.y + xOffset + _Time.y * 0.05) * TAU * 50 ) * 2.5;
                t *= 1-i.uv.y;

                float4 gradient = lerp( _ColorA, _ColorB, i.uv.y );

                return gradient * t;

                //return t;
            }

            ENDCG
        }
    }
}

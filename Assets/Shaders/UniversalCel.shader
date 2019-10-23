Shader "Unlit/UniversalCel"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

		_CelLevel("Cel Level", Range(1, 10)) = 2

		_Ambient("Ambient Light", Color) = (1, 1, 1, 1)

		_Color ("Color", Color) = (1, 1, 1, 1)

		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineSize("Outline Size", Range(0.001, 1)) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque"
			   "LightMode"="ForwardBase"
			   }
        LOD 100

		Pass {
			Cull Front
			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

			#include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
                float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float _OutlineSize;
			float4 _OutlineColor;

            v2f vert (appdata v)
            {
                v2f o;
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				
				o.viewDir = WorldSpaceViewDir(v.vertex);
				
				//if(dot(o.worldNormal, o.viewDir) <= 0) {
					v.vertex *= (1 + _OutlineSize); //float4(o.worldNormal.x, o.worldNormal.y, o.worldNormal.z, 1) * _OutlineSize;
				//}
				o.pos = UnityObjectToClipPos(v.vertex);

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				return(_OutlineColor);
            }
            ENDCG
		
		}

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
			#pragma multi_compile_fwdbase
			#pragma multi_compile_shadowcaster
	

            #include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
                float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				UNITY_FOG_COORDS(1)
				SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			float _CelLevel;

			float4 _Ambient;
			float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				
                UNITY_TRANSFER_FOG(o,o.vertex);
				TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float lvls = floor(_CelLevel);


				float4 Ka = _Ambient;

				// calc diffuse light
				float3 viewDir = normalize(i.viewDir);
				float3 normal = normalize(i.worldNormal);

				float NdotL = max(0, dot(normal, _WorldSpaceLightPos0));

				//float intensity = smoothstep(0, 0.01, NdotL * SHADOW_ATTENUATION(i));

				float sample = round(NdotL * SHADOW_ATTENUATION(i) * lvls) / lvls;

				float intensity = sample;

				float4 Kd = intensity * _LightColor0;

                // sample the texture
                fixed4 tex = tex2D(_MainTex, i.uv);		

				return fixed4((Ka + Kd) * _Color * tex);
            }
            ENDCG
        }
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}

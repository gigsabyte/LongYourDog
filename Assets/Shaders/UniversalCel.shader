Shader "Unlit/UniversalCel"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

		_CelLevel("Cel Level", Range(1, 10)) = 2

		_Ambient("Ambient Light", Color) = (1, 1, 1, 1)

		_Color ("Color", Color) = (1, 1, 1, 1)
		_SpecularColor("Specular Color", Color) = (0.9, 0.9, 0.9, 1)
		_SpecExp("Glossiness", Range(2, 128)) = 32

		_RimLightColor("Rim Light Color", Color) = (1, 1, 1, 1)
		_RimLightAmt("Rim Light Amount", Range(0, 1)) = 0.7
		_RimBlending("Rim Blending", Range(0, 1)) = 0.1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque"
			   "LightMode"="ForwardBase"
			   }
        LOD 100

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
			float4 _SpecularColor;
			float _SpecExp;

			float4 _RimLightColor;
			float _RimLightAmt;
			float _RimBlending;

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

				// calc spec Light
				//float RdotV = max(0, dot(reflect(_WorldSpaceLightPos0, normal), viewDir));
				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
				float NdotH = dot(normal, halfVector);

				float specIntensity = pow(NdotH * intensity, _SpecExp * _SpecExp);

				specIntensity = smoothstep(0.005, 0.01, specIntensity);

				float4 Ks = specIntensity * _SpecularColor;

				// calc rim Light
				float rimDot = 1 - dot(viewDir, normal);

				float rimIntensity = rimDot * pow(NdotL, _RimBlending);
				rimIntensity = smoothstep(_RimLightAmt - 0.01, _RimLightAmt + 0.01, rimIntensity);
				//float rimIntensity = rimDot * pow(NdotL, _RimBlending);
				//rimIntensity = smoothstep(_RimLightAmt - 0.01, _RimLightAmt + 0.01, _RimBlending);
				//float4 rim = rimIntensity * _RimColor;
				float4 Kr = rimIntensity * _RimLightColor;

                // sample the texture
                fixed4 tex = tex2D(_MainTex, i.uv);

		

				return fixed4((Ka + Kd + Ks + Kr) * _Color * tex);
            }
            ENDCG
        }
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}

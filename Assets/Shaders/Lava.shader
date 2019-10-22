Shader "Environment/Lava"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BaseColor("Base Color", Color) = (1, 1, 1, 1)
		_PeakColor("Peak Color", Color) = (1, 1, 1, 1)
		_HeightVariation("Height Variation", Range(0.1, 10)) = 1
		_Levels("Levels", Range(1, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
				float2 newuv : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _BaseColor;
			float4 _PeakColor;
			float _HeightVariation;
			float _Levels;


			float random (float2 st) {
				return frac(sin(dot(st.xy,
									 float2(12.9898,78.233)))
							 * 43758.5453123);
			}

			float noise (float2 st) {
				float2 i = floor(st);
				float2 f = frac(st);

				// Four corners in 2D of a tile
				float a = random(i);
				float b = random(i + float2(1.0, 0.0));
				float c = random(i + float2(0.0, 1.0));
				float d = random(i + float2(1.0, 1.0));

				// Smooth Interpolation

				// Cubic Hermine Curve.  Same as SmoothStep()
				float2 u = f*f*(3.0-2.0*f);
				// u = smoothstep(0.,1.,f);

				// Mix 4 coorners percentages
				return lerp(a, b, u.x) +
						(c - a)* u.y * (1.0 - u.x) +
						(d - b) * u.x * u.y;
			}

            v2f vert (appdata v)
            {
                v2f o;
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				//float4 f = float4(v.uv.x, v.uv.y, 1, 1);
				//fixed4 noise = tex2Dlod( _MainTex, f);
				//v.vertex.y 
                o.vertex = UnityObjectToClipPos(v.vertex);
				float2 newuv = float2(o.uv.x + v.vertex.x + _Time.y/10, o.uv.y + v.vertex.z - _Time.y/10);
				o.vertex.y += (noise(newuv)) * _HeightVariation;//(tan(o.uv.x * o.uv.y) * _HeightVariation/10 * sin(_Time.y)/10) * 0.25;

				o.newuv = newuv;

                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float sample = noise(i.newuv);

				float lvls = floor(_Levels);

				sample = round(sample * lvls) / lvls;
				
				float r = lerp(_BaseColor.r, _PeakColor.r, sample);
				float g = lerp(_BaseColor.g, _PeakColor.g, sample);
				float b = lerp(_BaseColor.b, _PeakColor.b, sample);

				fixed4 col = fixed4(r, g, b, 1.0f);

				
				

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}

Shader "Diffuse Scroll Transparent Mask"
{

	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_AlphaTex("Mask (RGB)", 2D) = "white" {}
		_ScrollU("Scroll Speed U", float) = 1
		_ScrollV("Scroll Speed V", float) = 1
		_Progress("Progress", float) = 0.5
	}

		CGINCLUDE

			struct v2f_full
		{
			float4 pos : SV_POSITION;
			half4 uv : TEXCOORD0;
		};

#include "UnityCG.cginc"        

		sampler2D _MainTex;
		sampler2D _AlphaTex;
		float _ScrollU;
		float _ScrollV;
		float _Progress;

		ENDCG

			SubShader
		{
			Tags { "RenderType" = "Transparent" }
			LOD 200
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				Tags { "LightMode" = "Vertex" }

				CGPROGRAM

				half4 _MainTex_ST;
				half4 _AlphaTex_ST;

				v2f_full vert(appdata_full v)
				{
					v2f_full o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
					o.uv.zw = TRANSFORM_TEX(v.texcoord, _AlphaTex);

					o.uv.x += frac(_Time * _ScrollU);
					o.uv.y += frac(_Time * _ScrollV);

					return o;
				}

				fixed4 frag(v2f_full i) : COLOR0
				{
					fixed4 tex = tex2D(_MainTex, i.uv.xy);
					fixed3 texAlpha = tex2D(_AlphaTex, i.uv.zw).rgb;
					tex.a *= texAlpha.r < _Progress;

					return tex;
				}

				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest 

				ENDCG
			}
		}

			Fallback "Mobile/Texture"
}
// COMP30019 - Project 2
// Custom Shader created by Erwin Haryantho (664480)
// refrenced from : http://answers.unity3d.com/questions/1068035/fog-not-working-in-my-own-vertext-shader.html

Shader "Custom/Fog" {

	Properties{
		_FogColor("FogColor", Color) = (1,1,1,1)
		_Intensity("Intensity", Range(0,1)) = 0.5
		_Cloud("Cloud", Range(0,5)) = 1
		_FogDensity("FogDensity", Range(0, 0.25)) = 0.1
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}

		SubShader{
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
			Cull Off
			ZWrite off
			ZTest LEqual
			ColorMask RGBA
			Blend SrcAlpha OneMinusSrcAlpha
			Fog{}

			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag 
				#pragma multi_compile_fog
				#pragma target 3.0

				#include "UnityCG.cginc"

				float4 _FogColor;
				float _Intensity;	// fog color intensity
				float _Cloud;		// indicator of how clouded the fog is
				float _FogDensity;
				sampler2D _MainTex;

				struct vertOut {
					float4 vertex : SV_POSITION;
					float4 color: COLOR;
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
				};

				vertOut vert(appdata_full v) {
					vertOut o;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);	
					o.color = v.color;
					o.uv = v.texcoord;					
					UNITY_TRANSFER_FOG(o, o.vertex);
					return o;
				}

				fixed4 frag(vertOut v) : COLOR{
					
					float4 c = tex2D(_MainTex, v.uv*_Cloud);
					float r_in = c.r*_Intensity;
					float cons = 2.5; // smoothing constant
					c.a = c.r;
					c.rgb = float3(r_in*_FogColor.r,r_in*_FogColor.g,r_in*_FogColor.b);
					c.a *= v.color.a - cons*length(v.uv - float2(0.5, 0.5)); // smooth the effect of the fog
					c.a *= _FogDensity;
					UNITY_APPLY_FOG(v.fogCoord, col);
					return c;
				}
				ENDCG
			}
	}
}




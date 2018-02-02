﻿Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
        _SecondaryColor ("Secondary Color", Color) = (1,1,1,1) // 追加...第2の色
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
        _SeparationHeight ("Separation Height", Float) = 0.0 // 追加...ワールドYがこれより上なら_Color、下なら_SecondaryColorで塗ることにする
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex; 
            float3 worldPos; // 追加...注目点のワールド空間内の座標が自動的に入れられる
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
        fixed4 _SecondaryColor; // 追加...追加したプロパティの値を受け取る変数
        float _SeparationHeight; // 追加...追加したプロパティの値を受け取る変数
       
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
             // 変更...surf内でworldPosを受け取れるようになったので、追加したプロパティ_SeparationHeightとY座標を比較し、_Colorと_SecondaryColorを切り替えてテクスチャ色に掛ける
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * lerp(_SecondaryColor, _Color, step(_SeparationHeight, IN.worldPos.y));
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}

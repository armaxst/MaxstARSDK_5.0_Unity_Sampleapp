Shader "MaxstAR/RGBABackground" {
    Properties {
        _MainTex ("Base (RGBA)", 2D) = "black" {}
    }
    SubShader {
        Tags {"Queue"="background" "RenderType"="opaque" }
        Pass {
            Cull Off
            ZWrite Off
            Lighting Off

            SetTexture [_MainTex] {
                combine texture 
            }
        }
    } 
    FallBack "Unlit/Texture"
}

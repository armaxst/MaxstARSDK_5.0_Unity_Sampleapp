// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32743,y:32813,varname:node_2865,prsc:2|diff-4658-OUT,spec-9328-OUT,normal-2465-OUT,emission-7138-OUT,voffset-7310-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:31597,y:32105,varname:node_6343,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Color,id:6665,x:31369,y:32211,ptovrint:False,ptlb:TextureColor,ptin:_TextureColor,varname:_TextureColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31369,y:31989,ptovrint:True,ptlb:TextureMap,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:31433,y:32790,ptovrint:True,ptlb:NormalMap,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:31049,y:32671,ptovrint:False,ptlb:Smoothness,ptin:_Smoothness,varname:_Smoothness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9777,x:30601,y:32435,ptovrint:False,ptlb:SpecularMap,ptin:_SpecularMap,varname:_SpecularMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9328,x:31484,y:32603,varname:node_9328,prsc:2|A-8972-OUT,B-358-OUT;n:type:ShaderForge.SFN_Tex2d,id:4961,x:31783,y:33757,ptovrint:False,ptlb:HeightMap,ptin:_HeightMap,varname:_HeightMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Vector1,id:410,x:31430,y:33593,varname:node_410,prsc:2,v1:0.01;n:type:ShaderForge.SFN_Slider,id:2459,x:31324,y:33716,ptovrint:False,ptlb:HeightmapIntensity,ptin:_HeightmapIntensity,varname:_HeightmapIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:5;n:type:ShaderForge.SFN_Multiply,id:4509,x:31783,y:33579,varname:node_4509,prsc:2|A-410-OUT,B-2459-OUT;n:type:ShaderForge.SFN_Multiply,id:9529,x:32049,y:33595,varname:node_9529,prsc:2|A-4509-OUT,B-4961-RGB;n:type:ShaderForge.SFN_NormalVector,id:8513,x:32049,y:33726,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:7310,x:32304,y:33567,varname:node_7310,prsc:2|A-9529-OUT,B-8513-OUT;n:type:ShaderForge.SFN_Tex2d,id:4069,x:30247,y:32054,ptovrint:False,ptlb:CloudMap,ptin:_CloudMap,varname:_CloudMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-3503-UVOUT;n:type:ShaderForge.SFN_Panner,id:3503,x:30042,y:32054,varname:node_3503,prsc:2,spu:0.05,spv:0|UVIN-638-UVOUT,DIST-3476-OUT;n:type:ShaderForge.SFN_TexCoord,id:638,x:29786,y:32052,varname:node_638,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:4658,x:32148,y:32071,varname:node_4658,prsc:2|A-2392-OUT,B-8604-OUT;n:type:ShaderForge.SFN_Color,id:6175,x:30151,y:32292,ptovrint:False,ptlb:CloudColor,ptin:_CloudColor,varname:_CloudColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2392,x:30477,y:32054,varname:node_2392,prsc:2|A-4069-RGB,B-6175-RGB;n:type:ShaderForge.SFN_Slider,id:4872,x:29514,y:32432,ptovrint:False,ptlb:CloudPanSpeed,ptin:_CloudPanSpeed,varname:_CloudPanSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:3720,x:29671,y:32224,varname:node_3720,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3476,x:29859,y:32206,varname:node_3476,prsc:2|A-3720-T,B-4872-OUT;n:type:ShaderForge.SFN_Subtract,id:8972,x:31345,y:32469,varname:node_8972,prsc:2|A-2868-OUT,B-1830-OUT;n:type:ShaderForge.SFN_Fresnel,id:79,x:31007,y:32978,varname:node_79,prsc:2|EXP-5528-OUT;n:type:ShaderForge.SFN_Slider,id:2491,x:30353,y:33078,ptovrint:False,ptlb:AtmosphereDensity,ptin:_AtmosphereDensity,varname:_AtmosphereDensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:8;n:type:ShaderForge.SFN_Color,id:5886,x:30573,y:33193,ptovrint:False,ptlb:AtmosphereColor,ptin:_AtmosphereColor,varname:_AtmosphereColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4411765,c2:0.6300204,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:6237,x:30470,y:32963,varname:node_6237,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:5528,x:30750,y:32990,varname:node_5528,prsc:2|A-6237-OUT,B-2491-OUT;n:type:ShaderForge.SFN_Multiply,id:8303,x:31236,y:33225,varname:node_8303,prsc:2|A-79-OUT,B-5886-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5930,x:31618,y:32995,ptovrint:False,ptlb:NormalMapIntensity,ptin:_NormalMapIntensity,varname:_NormalMapIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:2098,x:31953,y:32844,varname:node_2098,prsc:2|A-720-OUT,B-5930-OUT;n:type:ShaderForge.SFN_ComponentMask,id:720,x:31669,y:32790,varname:node_720,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5964-RGB;n:type:ShaderForge.SFN_Append,id:2465,x:32174,y:32890,varname:node_2465,prsc:2|A-2098-OUT,B-1496-OUT;n:type:ShaderForge.SFN_Vector1,id:1496,x:31849,y:33033,varname:node_1496,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1830,x:31118,y:32135,varname:node_1830,prsc:2|A-2392-OUT,B-1156-OUT;n:type:ShaderForge.SFN_Slider,id:1156,x:30676,y:32311,ptovrint:False,ptlb:CloudMapSpecularity,ptin:_CloudMapSpecularity,varname:_CloudMapSpecularity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:2868,x:30967,y:32458,varname:node_2868,prsc:2|A-9777-RGB,B-1991-OUT;n:type:ShaderForge.SFN_LightVector,id:5723,x:30563,y:33564,varname:node_5723,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2420,x:30563,y:33387,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:9817,x:30878,y:33414,varname:node_9817,prsc:2,dt:0|A-2420-OUT,B-5723-OUT;n:type:ShaderForge.SFN_Multiply,id:7768,x:31741,y:33215,varname:node_7768,prsc:2|A-8303-OUT,B-6365-OUT;n:type:ShaderForge.SFN_Add,id:1635,x:31222,y:33407,varname:node_1635,prsc:2|A-9817-OUT,B-5570-OUT;n:type:ShaderForge.SFN_Slider,id:5570,x:30799,y:33603,ptovrint:False,ptlb:LightStretch,ptin:_LightStretch,varname:_LightStretch,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.5;n:type:ShaderForge.SFN_Clamp01,id:6365,x:31470,y:33331,varname:node_6365,prsc:2|IN-1635-OUT;n:type:ShaderForge.SFN_Add,id:8604,x:31846,y:32091,varname:node_8604,prsc:2|A-2906-OUT,B-6343-OUT;n:type:ShaderForge.SFN_Multiply,id:2906,x:30413,y:31252,varname:node_2906,prsc:2|A-7597-OUT,B-6340-OUT;n:type:ShaderForge.SFN_Tex2d,id:8514,x:29843,y:31343,ptovrint:False,ptlb:CityLightMap,ptin:_CityLightMap,varname:node_8514,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Vector1,id:5094,x:29634,y:31209,varname:node_5094,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:8437,x:29843,y:31090,varname:node_8437,prsc:2|A-4296-OUT,B-5094-OUT;n:type:ShaderForge.SFN_Multiply,id:7597,x:30017,y:31148,varname:node_7597,prsc:2|A-8437-OUT,B-1930-OUT;n:type:ShaderForge.SFN_Vector1,id:1930,x:29843,y:31229,varname:node_1930,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:7138,x:32134,y:33161,varname:node_7138,prsc:2|A-9612-OUT,B-7768-OUT;n:type:ShaderForge.SFN_Desaturate,id:6582,x:30910,y:31567,varname:node_6582,prsc:2|COL-2906-OUT;n:type:ShaderForge.SFN_LightVector,id:8751,x:29205,y:31164,varname:node_8751,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:784,x:29205,y:30987,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:4296,x:29520,y:31014,varname:node_4296,prsc:2,dt:0|A-784-OUT,B-8751-OUT;n:type:ShaderForge.SFN_Subtract,id:566,x:31514,y:32381,varname:node_566,prsc:2|A-6582-OUT,B-2392-OUT;n:type:ShaderForge.SFN_Clamp01,id:9612,x:31751,y:32352,varname:node_9612,prsc:2|IN-566-OUT;n:type:ShaderForge.SFN_Color,id:8869,x:29843,y:31532,ptovrint:False,ptlb:CityLightColor,ptin:_CityLightColor,varname:node_8869,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:1991,x:30459,y:32698,ptovrint:False,ptlb:SpecularMapIntensity,ptin:_SpecularMapIntensity,varname:node_1991,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Multiply,id:9982,x:30051,y:31590,varname:node_9982,prsc:2|A-8869-RGB,B-3950-OUT;n:type:ShaderForge.SFN_Multiply,id:6340,x:30205,y:31426,varname:node_6340,prsc:2|A-8514-RGB,B-9982-OUT;n:type:ShaderForge.SFN_Slider,id:3950,x:29686,y:31734,ptovrint:False,ptlb:CityLightIntensity,ptin:_CityLightIntensity,varname:node_3950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;proporder:7736-6665-8514-8869-3950-4069-6175-1156-4872-9777-1991-358-5964-5930-4961-2459-5886-2491-5570;pass:END;sub:END;*/

Shader "AHProxy/PlanetShaderHi" {
    Properties {
        _MainTex ("TextureMap", 2D) = "white" {}
        _TextureColor ("TextureColor", Color) = (1,1,1,1)
        _CityLightMap ("CityLightMap", 2D) = "black" {}
        _CityLightColor ("CityLightColor", Color) = (1,1,1,1)
        _CityLightIntensity ("CityLightIntensity", Range(0, 2)) = 0
        _CloudMap ("CloudMap", 2D) = "black" {}
        _CloudColor ("CloudColor", Color) = (1,1,1,1)
        _CloudMapSpecularity ("CloudMapSpecularity", Range(-1, 1)) = 0
        _CloudPanSpeed ("CloudPanSpeed", Range(-1, 1)) = 0
        _SpecularMap ("SpecularMap", 2D) = "black" {}
        _SpecularMapIntensity ("SpecularMapIntensity", Range(0, 1)) = 0.4
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _BumpMap ("NormalMap", 2D) = "bump" {}
        _NormalMapIntensity ("NormalMapIntensity", Float ) = 1
        _HeightMap ("HeightMap", 2D) = "black" {}
        _HeightmapIntensity ("HeightmapIntensity", Range(0, 5)) = 5
        _AtmosphereColor ("AtmosphereColor", Color) = (0.4411765,0.6300204,1,1)
        _AtmosphereDensity ("AtmosphereDensity", Range(0, 8)) = 0
        _LightStretch ("LightStretch", Range(0, 0.5)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TextureColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _HeightmapIntensity;
            uniform sampler2D _CloudMap; uniform float4 _CloudMap_ST;
            uniform float4 _CloudColor;
            uniform float _CloudPanSpeed;
            uniform float _AtmosphereDensity;
            uniform float4 _AtmosphereColor;
            uniform float _NormalMapIntensity;
            uniform float _CloudMapSpecularity;
            uniform float _LightStretch;
            uniform sampler2D _CityLightMap; uniform float4 _CityLightMap_ST;
            uniform float4 _CityLightColor;
            uniform float _SpecularMapIntensity;
            uniform float _CityLightIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 _HeightMap_var = tex2Dlod(_HeightMap,float4(TRANSFORM_TEX(o.uv0, _HeightMap),0.0,0));
                v.vertex.xyz += (((0.01*_HeightmapIntensity)*_HeightMap_var.rgb)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = float3((_BumpMap_var.rgb.rg*_NormalMapIntensity),1.0);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float4 node_3720 = _Time;
                float2 node_3503 = (i.uv0+(node_3720.g*_CloudPanSpeed)*float2(0.05,0));
                float4 _CloudMap_var = tex2D(_CloudMap,TRANSFORM_TEX(node_3503, _CloudMap));
                float3 node_2392 = (_CloudMap_var.rgb*_CloudColor.rgb);
                float3 specularColor = (((_SpecularMap_var.rgb*_SpecularMapIntensity)-(node_2392*_CloudMapSpecularity))*_Smoothness);
                float specularMonochrome;
                float4 _CityLightMap_var = tex2D(_CityLightMap,TRANSFORM_TEX(i.uv0, _CityLightMap));
                float3 node_2906 = (((dot(i.normalDir,lightDirection)-0.5)*(-1.0))*(_CityLightMap_var.rgb*(_CityLightColor.rgb*_CityLightIntensity)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (node_2392+(node_2906+(_MainTex_var.rgb*_TextureColor.rgb))); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (saturate((dot(node_2906,float3(0.3,0.59,0.11))-node_2392))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),(8.0-_AtmosphereDensity))*_AtmosphereColor.rgb)*saturate((dot(i.normalDir,lightDirection)+_LightStretch))));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TextureColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _HeightmapIntensity;
            uniform sampler2D _CloudMap; uniform float4 _CloudMap_ST;
            uniform float4 _CloudColor;
            uniform float _CloudPanSpeed;
            uniform float _AtmosphereDensity;
            uniform float4 _AtmosphereColor;
            uniform float _NormalMapIntensity;
            uniform float _CloudMapSpecularity;
            uniform float _LightStretch;
            uniform sampler2D _CityLightMap; uniform float4 _CityLightMap_ST;
            uniform float4 _CityLightColor;
            uniform float _SpecularMapIntensity;
            uniform float _CityLightIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 _HeightMap_var = tex2Dlod(_HeightMap,float4(TRANSFORM_TEX(o.uv0, _HeightMap),0.0,0));
                v.vertex.xyz += (((0.01*_HeightmapIntensity)*_HeightMap_var.rgb)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = float3((_BumpMap_var.rgb.rg*_NormalMapIntensity),1.0);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float4 node_3720 = _Time;
                float2 node_3503 = (i.uv0+(node_3720.g*_CloudPanSpeed)*float2(0.05,0));
                float4 _CloudMap_var = tex2D(_CloudMap,TRANSFORM_TEX(node_3503, _CloudMap));
                float3 node_2392 = (_CloudMap_var.rgb*_CloudColor.rgb);
                float3 specularColor = (((_SpecularMap_var.rgb*_SpecularMapIntensity)-(node_2392*_CloudMapSpecularity))*_Smoothness);
                float specularMonochrome;
                float4 _CityLightMap_var = tex2D(_CityLightMap,TRANSFORM_TEX(i.uv0, _CityLightMap));
                float3 node_2906 = (((dot(i.normalDir,lightDirection)-0.5)*(-1.0))*(_CityLightMap_var.rgb*(_CityLightColor.rgb*_CityLightIntensity)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (node_2392+(node_2906+(_MainTex_var.rgb*_TextureColor.rgb))); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _HeightmapIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 _HeightMap_var = tex2Dlod(_HeightMap,float4(TRANSFORM_TEX(o.uv0, _HeightMap),0.0,0));
                v.vertex.xyz += (((0.01*_HeightmapIntensity)*_HeightMap_var.rgb)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TextureColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _HeightmapIntensity;
            uniform sampler2D _CloudMap; uniform float4 _CloudMap_ST;
            uniform float4 _CloudColor;
            uniform float _CloudPanSpeed;
            uniform float _AtmosphereDensity;
            uniform float4 _AtmosphereColor;
            uniform float _CloudMapSpecularity;
            uniform float _LightStretch;
            uniform sampler2D _CityLightMap; uniform float4 _CityLightMap_ST;
            uniform float4 _CityLightColor;
            uniform float _SpecularMapIntensity;
            uniform float _CityLightIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 _HeightMap_var = tex2Dlod(_HeightMap,float4(TRANSFORM_TEX(o.uv0, _HeightMap),0.0,0));
                v.vertex.xyz += (((0.01*_HeightmapIntensity)*_HeightMap_var.rgb)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _CityLightMap_var = tex2D(_CityLightMap,TRANSFORM_TEX(i.uv0, _CityLightMap));
                float3 node_2906 = (((dot(i.normalDir,lightDirection)-0.5)*(-1.0))*(_CityLightMap_var.rgb*(_CityLightColor.rgb*_CityLightIntensity)));
                float4 node_3720 = _Time;
                float2 node_3503 = (i.uv0+(node_3720.g*_CloudPanSpeed)*float2(0.05,0));
                float4 _CloudMap_var = tex2D(_CloudMap,TRANSFORM_TEX(node_3503, _CloudMap));
                float3 node_2392 = (_CloudMap_var.rgb*_CloudColor.rgb);
                o.Emission = (saturate((dot(node_2906,float3(0.3,0.59,0.11))-node_2392))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),(8.0-_AtmosphereDensity))*_AtmosphereColor.rgb)*saturate((dot(i.normalDir,lightDirection)+_LightStretch))));
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffColor = (node_2392+(node_2906+(_MainTex_var.rgb*_TextureColor.rgb)));
                float4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float3 specColor = (((_SpecularMap_var.rgb*_SpecularMapIntensity)-(node_2392*_CloudMapSpecularity))*_Smoothness);
                float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
                diffColor *= (1.0-specularMonochrome);
                o.Albedo = diffColor + specColor * 0.125; // No gloss connected. Assume it's 0.5
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

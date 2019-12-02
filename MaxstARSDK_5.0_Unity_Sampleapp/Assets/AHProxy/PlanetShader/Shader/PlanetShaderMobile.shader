// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:1,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:True,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:14,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32743,y:32813,varname:node_2865,prsc:2|diff-3362-OUT,spec-9328-OUT,normal-5964-RGB,emission-3027-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31450,y:32121,ptovrint:True,ptlb:TextureMap,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:31433,y:32790,ptovrint:True,ptlb:NormalMap,ptin:_BumpMap,varname:_BumpMap,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:30688,y:32693,ptovrint:False,ptlb:Smoothness,ptin:_Smoothness,varname:_Smoothness,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9777,x:30601,y:32435,ptovrint:False,ptlb:SpecularMap,ptin:_SpecularMap,varname:_SpecularMap,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9328,x:31516,y:32609,varname:node_9328,prsc:2|A-8972-OUT,B-9998-OUT;n:type:ShaderForge.SFN_Tex2d,id:4069,x:30433,y:32086,ptovrint:False,ptlb:CloudMap,ptin:_CloudMap,varname:_CloudMap,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-3503-UVOUT;n:type:ShaderForge.SFN_Panner,id:3503,x:30228,y:32086,varname:node_3503,prsc:1,spu:0.05,spv:0|UVIN-638-UVOUT,DIST-3476-OUT;n:type:ShaderForge.SFN_TexCoord,id:638,x:29972,y:32084,varname:node_638,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:4658,x:31747,y:32084,varname:node_4658,prsc:2|A-4069-RGB,B-7736-RGB;n:type:ShaderForge.SFN_Slider,id:4872,x:29700,y:32455,ptovrint:False,ptlb:CloudPanSpeed,ptin:_CloudPanSpeed,varname:_CloudPanSpeed,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:3720,x:29857,y:32256,varname:node_3720,prsc:1;n:type:ShaderForge.SFN_Multiply,id:3476,x:30045,y:32238,varname:node_3476,prsc:2|A-3720-T,B-4872-OUT;n:type:ShaderForge.SFN_Subtract,id:8972,x:31345,y:32469,varname:node_8972,prsc:2|A-9777-RGB,B-1830-OUT;n:type:ShaderForge.SFN_Fresnel,id:79,x:31007,y:32978,varname:node_79,prsc:2|EXP-5528-OUT;n:type:ShaderForge.SFN_Slider,id:2491,x:30353,y:33078,ptovrint:False,ptlb:AtmosphereDensity,ptin:_AtmosphereDensity,varname:_AtmosphereDensity,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:8;n:type:ShaderForge.SFN_Color,id:5886,x:30573,y:33193,ptovrint:False,ptlb:AtmosphereColor,ptin:_AtmosphereColor,varname:_AtmosphereColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4411765,c2:0.6300204,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:6237,x:30470,y:32963,varname:node_6237,prsc:2,v1:8;n:type:ShaderForge.SFN_Subtract,id:5528,x:30750,y:32990,varname:node_5528,prsc:2|A-6237-OUT,B-2491-OUT;n:type:ShaderForge.SFN_Multiply,id:8303,x:31236,y:33225,varname:node_8303,prsc:2|A-79-OUT,B-5886-RGB;n:type:ShaderForge.SFN_Multiply,id:1830,x:31118,y:32135,varname:node_1830,prsc:2|A-4069-RGB,B-1156-OUT;n:type:ShaderForge.SFN_Slider,id:1156,x:30676,y:32311,ptovrint:False,ptlb:CloudMapSpecularity,ptin:_CloudMapSpecularity,varname:_CloudMapSpecularity,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_LightVector,id:5723,x:30563,y:33564,varname:node_5723,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2420,x:30563,y:33387,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:9817,x:30878,y:33414,varname:node_9817,prsc:2,dt:0|A-2420-OUT,B-5723-OUT;n:type:ShaderForge.SFN_Multiply,id:7768,x:31741,y:33215,varname:node_7768,prsc:2|A-8303-OUT,B-6365-OUT;n:type:ShaderForge.SFN_Add,id:1635,x:31222,y:33407,varname:node_1635,prsc:2|A-9817-OUT,B-5570-OUT;n:type:ShaderForge.SFN_Slider,id:5570,x:30799,y:33603,ptovrint:False,ptlb:LightStretch,ptin:_LightStretch,varname:_LightStretch,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.5;n:type:ShaderForge.SFN_Clamp01,id:6365,x:31470,y:33331,varname:node_6365,prsc:2|IN-1635-OUT;n:type:ShaderForge.SFN_Vector1,id:3219,x:30855,y:32833,varname:node_3219,prsc:0,v1:0.2;n:type:ShaderForge.SFN_Add,id:9998,x:31092,y:32721,varname:node_9998,prsc:2|A-358-OUT,B-3219-OUT;n:type:ShaderForge.SFN_Multiply,id:6430,x:30500,y:31504,varname:node_6430,prsc:2|A-8485-OUT,B-9765-OUT;n:type:ShaderForge.SFN_Tex2d,id:7461,x:29930,y:31595,ptovrint:False,ptlb:CityLightMap,ptin:_CityLightMap,varname:node_8514,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Vector1,id:926,x:29721,y:31461,varname:node_926,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:8565,x:29930,y:31342,varname:node_8565,prsc:2|A-2419-OUT,B-926-OUT;n:type:ShaderForge.SFN_Multiply,id:8485,x:30104,y:31400,varname:node_8485,prsc:2|A-8565-OUT,B-6412-OUT;n:type:ShaderForge.SFN_Vector1,id:6412,x:29930,y:31481,varname:node_6412,prsc:2,v1:-1;n:type:ShaderForge.SFN_Desaturate,id:8746,x:30997,y:31819,varname:node_8746,prsc:2|COL-6430-OUT;n:type:ShaderForge.SFN_LightVector,id:9024,x:29292,y:31416,varname:node_9024,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:6689,x:29292,y:31239,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:2419,x:29607,y:31266,varname:node_2419,prsc:2,dt:0|A-6689-OUT,B-9024-OUT;n:type:ShaderForge.SFN_Multiply,id:2652,x:30138,y:31842,varname:node_2652,prsc:2|A-6787-RGB,B-8050-OUT;n:type:ShaderForge.SFN_Multiply,id:9765,x:30292,y:31678,varname:node_9765,prsc:2|A-7461-RGB,B-2652-OUT;n:type:ShaderForge.SFN_Slider,id:8050,x:29773,y:31986,ptovrint:False,ptlb:CityLightIntensity,ptin:_CityLightIntensity,varname:node_3950,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Subtract,id:6235,x:31573,y:32399,varname:node_6235,prsc:2|A-8746-OUT,B-4069-RGB;n:type:ShaderForge.SFN_Clamp01,id:6930,x:31823,y:32424,varname:node_6930,prsc:2|IN-6235-OUT;n:type:ShaderForge.SFN_Add,id:3027,x:32230,y:33074,varname:node_3027,prsc:2|A-6930-OUT,B-7768-OUT;n:type:ShaderForge.SFN_Color,id:6787,x:29905,y:31801,ptovrint:False,ptlb:CityLightColor,ptin:_CityLightColor,varname:node_6787,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:3362,x:32073,y:32005,varname:node_3362,prsc:2|A-6430-OUT,B-4658-OUT;proporder:7736-7461-4069-6787-8050-1156-4872-9777-358-5964-5886-2491-5570;pass:END;sub:END;*/

Shader "AHProxy/PlanetShaderLo" {
    Properties {
        _MainTex ("TextureMap", 2D) = "white" {}
        _CityLightMap ("CityLightMap", 2D) = "black" {}
        _CloudMap ("CloudMap", 2D) = "black" {}
        _CityLightColor ("CityLightColor", Color) = (1,1,1,1)
        _CityLightIntensity ("CityLightIntensity", Range(0, 2)) = 0
        _CloudMapSpecularity ("CloudMapSpecularity", Range(-1, 1)) = 0
        _CloudPanSpeed ("CloudPanSpeed", Range(-1, 1)) = 0
        _SpecularMap ("SpecularMap", 2D) = "black" {}
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        _BumpMap ("NormalMap", 2D) = "bump" {}
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
            
            ColorMask RGB
            
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform fixed _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _CloudMap; uniform float4 _CloudMap_ST;
            uniform fixed _CloudPanSpeed;
            uniform half _AtmosphereDensity;
            uniform fixed4 _AtmosphereColor;
            uniform fixed _CloudMapSpecularity;
            uniform fixed _LightStretch;
            uniform sampler2D _CityLightMap; uniform float4 _CityLightMap_ST;
            uniform float _CityLightIntensity;
            uniform float4 _CityLightColor;
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
                fixed3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
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
                fixed4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                half4 node_3720 = _Time;
                half2 node_3503 = (i.uv0+(node_3720.g*_CloudPanSpeed)*float2(0.05,0));
                fixed4 _CloudMap_var = tex2D(_CloudMap,TRANSFORM_TEX(node_3503, _CloudMap));
                float3 specularColor = ((_SpecularMap_var.rgb-(_CloudMap_var.rgb*_CloudMapSpecularity))*(_Smoothness+0.2));
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float normTerm = (specPow + 8.0 ) / (8.0 * Pi);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*normTerm*specularColor;
                float3 indirectSpecular = (gi.indirect.specular)*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float4 _CityLightMap_var = tex2D(_CityLightMap,TRANSFORM_TEX(i.uv0, _CityLightMap));
                float3 node_6430 = (((dot(i.normalDir,lightDirection)-0.5)*(-1.0))*(_CityLightMap_var.rgb*(_CityLightColor.rgb*_CityLightIntensity)));
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffuseColor = (node_6430+(_CloudMap_var.rgb+_MainTex_var.rgb));
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (saturate((dot(node_6430,float3(0.3,0.59,0.11))-_CloudMap_var.rgb))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),(8.0-_AtmosphereDensity))*_AtmosphereColor.rgb)*saturate((dot(i.normalDir,lightDirection)+_LightStretch))));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            ColorMask RGB
            
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed _Smoothness;
            uniform sampler2D _SpecularMap; uniform float4 _SpecularMap_ST;
            uniform sampler2D _CloudMap; uniform float4 _CloudMap_ST;
            uniform fixed _CloudPanSpeed;
            uniform half _AtmosphereDensity;
            uniform fixed4 _AtmosphereColor;
            uniform fixed _CloudMapSpecularity;
            uniform fixed _LightStretch;
            uniform sampler2D _CityLightMap; uniform float4 _CityLightMap_ST;
            uniform float _CityLightIntensity;
            uniform float4 _CityLightColor;
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
                float3 node_6430 = (((dot(i.normalDir,lightDirection)-0.5)*(-1.0))*(_CityLightMap_var.rgb*(_CityLightColor.rgb*_CityLightIntensity)));
                half4 node_3720 = _Time;
                half2 node_3503 = (i.uv0+(node_3720.g*_CloudPanSpeed)*float2(0.05,0));
                fixed4 _CloudMap_var = tex2D(_CloudMap,TRANSFORM_TEX(node_3503, _CloudMap));
                o.Emission = (saturate((dot(node_6430,float3(0.3,0.59,0.11))-_CloudMap_var.rgb))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),(8.0-_AtmosphereDensity))*_AtmosphereColor.rgb)*saturate((dot(i.normalDir,lightDirection)+_LightStretch))));
                
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffColor = (node_6430+(_CloudMap_var.rgb+_MainTex_var.rgb));
                fixed4 _SpecularMap_var = tex2D(_SpecularMap,TRANSFORM_TEX(i.uv0, _SpecularMap));
                float3 specColor = ((_SpecularMap_var.rgb-(_CloudMap_var.rgb*_CloudMapSpecularity))*(_Smoothness+0.2));
                o.Albedo = diffColor + specColor * 0.125; // No gloss connected. Assume it's 0.5
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

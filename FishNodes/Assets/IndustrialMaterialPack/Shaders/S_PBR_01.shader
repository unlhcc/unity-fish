// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:33007,y:32188,varname:node_2865,prsc:2|diff-2471-OUT,spec-4053-OUT,gloss-172-OUT,normal-1374-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:32019,y:31706,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6732-OUT;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32378,y:33116,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-6732-OUT;n:type:ShaderForge.SFN_Tex2d,id:1222,x:31680,y:32616,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:_Mask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6732-OUT;n:type:ShaderForge.SFN_ValueProperty,id:971,x:31856,y:33004,ptovrint:False,ptlb:RoughnessValue,ptin:_RoughnessValue,varname:_RoughnessValue,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:172,x:32424,y:32766,varname:node_172,prsc:2|A-2854-OUT,B-1994-OUT,T-3715-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2854,x:32141,y:32717,ptovrint:False,ptlb:MinRoughness,ptin:_MinRoughness,varname:_MinRoughness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1994,x:32141,y:32793,ptovrint:False,ptlb:MaxRoughness,ptin:_MaxRoughness,varname:_MaxRoughness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Blend,id:3715,x:32158,y:32867,varname:node_3715,prsc:2,blmd:10,clmp:True|SRC-1222-R,DST-971-OUT;n:type:ShaderForge.SFN_Blend,id:4053,x:32214,y:32487,varname:node_4053,prsc:2,blmd:10,clmp:True|SRC-1222-G,DST-8967-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8967,x:31936,y:32594,ptovrint:False,ptlb:MetalicValue,ptin:_MetalicValue,varname:_MetalicValue,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ViewVector,id:8901,x:30675,y:32020,varname:node_8901,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:6603,x:30675,y:32152,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:5455,x:30833,y:32080,varname:node_5455,prsc:2,dt:0|A-8901-OUT,B-6603-OUT;n:type:ShaderForge.SFN_Power,id:6934,x:31213,y:32080,varname:node_6934,prsc:2|VAL-9325-OUT,EXP-1414-OUT;n:type:ShaderForge.SFN_Clamp01,id:9325,x:31008,y:32080,varname:node_9325,prsc:2|IN-5455-OUT;n:type:ShaderForge.SFN_Vector1,id:1414,x:31008,y:32213,varname:node_1414,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:5884,x:31379,y:32007,varname:node_5884,prsc:2|A-2004-OUT,B-7177-OUT,T-6934-OUT;n:type:ShaderForge.SFN_Vector1,id:2004,x:31213,y:31969,varname:node_2004,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Vector1,id:7177,x:31213,y:32027,varname:node_7177,prsc:2,v1:0.9;n:type:ShaderForge.SFN_OneMinus,id:6102,x:31008,y:31826,varname:node_6102,prsc:2|IN-9325-OUT;n:type:ShaderForge.SFN_Power,id:3257,x:31200,y:31826,varname:node_3257,prsc:2|VAL-6102-OUT,EXP-3268-OUT;n:type:ShaderForge.SFN_Vector1,id:3268,x:31008,y:31951,varname:node_3268,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:8854,x:31569,y:31937,cmnt:Metal Shading END,varname:node_8854,prsc:2|A-3257-OUT,B-5884-OUT;n:type:ShaderForge.SFN_Multiply,id:2471,x:32681,y:32189,cmnt:Add MetalShading to BaseColor,varname:node_2471,prsc:2|A-94-OUT,B-8854-OUT;n:type:ShaderForge.SFN_Blend,id:94,x:32376,y:31639,varname:node_94,prsc:2,blmd:10,clmp:True|SRC-1123-OUT,DST-7736-RGB;n:type:ShaderForge.SFN_ValueProperty,id:1123,x:32019,y:31577,ptovrint:False,ptlb:Brighness,ptin:_Brighness,varname:_Brighness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:6270,x:32593,y:33144,varname:node_6270,prsc:2|A-5964-RGB,B-1153-OUT;n:type:ShaderForge.SFN_Add,id:1374,x:32790,y:33116,varname:node_1374,prsc:2|A-5964-RGB,B-6270-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1547,x:32174,y:33326,ptovrint:False,ptlb:NormalIntensity,ptin:_NormalIntensity,varname:_NormalIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:663,x:32341,y:33316,varname:node_663,prsc:2|A-1547-OUT,B-1547-OUT;n:type:ShaderForge.SFN_Append,id:1153,x:32529,y:33316,varname:node_1153,prsc:2|A-663-OUT,B-8477-OUT;n:type:ShaderForge.SFN_Vector1,id:8477,x:32341,y:33460,varname:node_8477,prsc:2,v1:0;n:type:ShaderForge.SFN_TexCoord,id:9617,x:30707,y:32442,varname:node_9617,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:6732,x:30966,y:32513,varname:node_6732,prsc:2|A-9617-UVOUT,B-9505-OUT;n:type:ShaderForge.SFN_ValueProperty,id:195,x:30571,y:32694,ptovrint:False,ptlb:U_Tiling,ptin:_U_Tiling,varname:_U_Tiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1286,x:30571,y:32773,ptovrint:False,ptlb:V_Tiling,ptin:_V_Tiling,varname:_V_Tiling,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:9505,x:30752,y:32694,varname:node_9505,prsc:2|A-195-OUT,B-1286-OUT;proporder:7736-5964-1222-8967-971-2854-1994-1123-1547-195-1286;pass:END;sub:END;*/

Shader "Shader Forge/S_PBR_01" {
    Properties {
        _MainTex ("Base Color", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Mask ("Mask", 2D) = "white" {}
        _MetalicValue ("MetalicValue", Float ) = 1
        _RoughnessValue ("RoughnessValue", Float ) = 0.5
        _MinRoughness ("MinRoughness", Float ) = 0
        _MaxRoughness ("MaxRoughness", Float ) = 1
        _Brighness ("Brighness", Float ) = 0.5
        _NormalIntensity ("NormalIntensity", Float ) = 0
        _U_Tiling ("U_Tiling", Float ) = 1
        _V_Tiling ("V_Tiling", Float ) = 1
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _RoughnessValue;
            uniform float _MinRoughness;
            uniform float _MaxRoughness;
            uniform float _MetalicValue;
            uniform float _Brighness;
            uniform float _NormalIntensity;
            uniform float _U_Tiling;
            uniform float _V_Tiling;
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
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float2 node_6732 = (i.uv0*float2(_U_Tiling,_V_Tiling));
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_6732, _BumpMap)));
                float3 normalLocal = (_BumpMap_var.rgb+(_BumpMap_var.rgb*float3(float2(_NormalIntensity,_NormalIntensity),0.0)));
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
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_6732, _Mask));
                float gloss = 1.0 - lerp(_MinRoughness,_MaxRoughness,saturate(( _RoughnessValue > 0.5 ? (1.0-(1.0-2.0*(_RoughnessValue-0.5))*(1.0-_Mask_var.r)) : (2.0*_RoughnessValue*_Mask_var.r) ))); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
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
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6732, _MainTex));
                float node_9325 = saturate(dot(viewDirection,i.normalDir));
                float3 diffuseColor = (saturate(( _MainTex_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_MainTex_var.rgb-0.5))*(1.0-_Brighness)) : (2.0*_MainTex_var.rgb*_Brighness) ))*(pow((1.0 - node_9325),4.0)+lerp(0.4,0.9,pow(node_9325,2.0)))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, saturate(( _MetalicValue > 0.5 ? (1.0-(1.0-2.0*(_MetalicValue-0.5))*(1.0-_Mask_var.g)) : (2.0*_MetalicValue*_Mask_var.g) )), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _RoughnessValue;
            uniform float _MinRoughness;
            uniform float _MaxRoughness;
            uniform float _MetalicValue;
            uniform float _Brighness;
            uniform float _NormalIntensity;
            uniform float _U_Tiling;
            uniform float _V_Tiling;
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
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float2 node_6732 = (i.uv0*float2(_U_Tiling,_V_Tiling));
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(node_6732, _BumpMap)));
                float3 normalLocal = (_BumpMap_var.rgb+(_BumpMap_var.rgb*float3(float2(_NormalIntensity,_NormalIntensity),0.0)));
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
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_6732, _Mask));
                float gloss = 1.0 - lerp(_MinRoughness,_MaxRoughness,saturate(( _RoughnessValue > 0.5 ? (1.0-(1.0-2.0*(_RoughnessValue-0.5))*(1.0-_Mask_var.r)) : (2.0*_RoughnessValue*_Mask_var.r) ))); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6732, _MainTex));
                float node_9325 = saturate(dot(viewDirection,i.normalDir));
                float3 diffuseColor = (saturate(( _MainTex_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_MainTex_var.rgb-0.5))*(1.0-_Brighness)) : (2.0*_MainTex_var.rgb*_Brighness) ))*(pow((1.0 - node_9325),4.0)+lerp(0.4,0.9,pow(node_9325,2.0)))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, saturate(( _MetalicValue > 0.5 ? (1.0-(1.0-2.0*(_MetalicValue-0.5))*(1.0-_Mask_var.g)) : (2.0*_MetalicValue*_Mask_var.g) )), specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _RoughnessValue;
            uniform float _MinRoughness;
            uniform float _MaxRoughness;
            uniform float _MetalicValue;
            uniform float _Brighness;
            uniform float _U_Tiling;
            uniform float _V_Tiling;
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
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float2 node_6732 = (i.uv0*float2(_U_Tiling,_V_Tiling));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6732, _MainTex));
                float node_9325 = saturate(dot(viewDirection,i.normalDir));
                float3 diffColor = (saturate(( _MainTex_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_MainTex_var.rgb-0.5))*(1.0-_Brighness)) : (2.0*_MainTex_var.rgb*_Brighness) ))*(pow((1.0 - node_9325),4.0)+lerp(0.4,0.9,pow(node_9325,2.0))));
                float specularMonochrome;
                float3 specColor;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_6732, _Mask));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, saturate(( _MetalicValue > 0.5 ? (1.0-(1.0-2.0*(_MetalicValue-0.5))*(1.0-_Mask_var.g)) : (2.0*_MetalicValue*_Mask_var.g) )), specColor, specularMonochrome );
                float roughness = lerp(_MinRoughness,_MaxRoughness,saturate(( _RoughnessValue > 0.5 ? (1.0-(1.0-2.0*(_RoughnessValue-0.5))*(1.0-_Mask_var.r)) : (2.0*_RoughnessValue*_Mask_var.r) )));
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

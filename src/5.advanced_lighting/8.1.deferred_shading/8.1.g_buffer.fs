#version 330 core
//layout (location = 0) out vec3 gPosition;
//layout (location = 1) out vec3 gNormal;
//layout (location = 2) out vec4 gAlbedoSpec;

layout (location = 0) out vec4 fragColor;

in vec2 TexCoords;
in vec3 FragPos;
in vec3 Normal;
in float logZ;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;
uniform float iTime;

float dither13(vec2 pos)
{
  return fract(dot(pos, vec2(4, 7) / 13.0));
}

void main()
{    
    // and the diffuse per-fragment color
    fragColor.rgb = texture(texture_diffuse1, TexCoords).rgb;
    fragColor.a = 1.0;
    //gl_FragDepth = logZ; 
    //float alpha = clamp((cos(iTime * 0.2) + 1.0) * 0.5, 0.0, 1.0);
    //fragColor.a = step(alpha, dither13(gl_FragCoord.xy));
}
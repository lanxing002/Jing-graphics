#version 330 core
layout (location = 0) out vec4 fragColor;

in vec3 FragPos;

uniform samplerCube skybox;

void main()
{    
    vec3 c = normalize(FragPos);
    //c = (c + 1.0) * 0.5;
    gl_FragDepth =0.999;
    fragColor = texture(skybox, -c);
}
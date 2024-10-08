#version 330 core
layout (location = 0) out vec4 fragColor;

in vec3 FragPos;


void main()
{    
    vec3 c = normalize(FragPos);
    c = (c + 1.0) * 0.5;
    fragColor = vec4(c, 1.0);
}
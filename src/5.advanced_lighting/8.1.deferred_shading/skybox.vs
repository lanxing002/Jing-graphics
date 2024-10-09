#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

out vec3 FragPos;

void main()
{
    FragPos = aPos;
    vec4 worldPos = vec4(aPos * 50.0, 1.0);
    vec4 pos = projection * view * worldPos;
    //pos = pos / pos.w;
    gl_Position = pos;

}
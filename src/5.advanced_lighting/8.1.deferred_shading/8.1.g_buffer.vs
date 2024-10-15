#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

out vec3 FragPos;
out vec2 TexCoords;
out vec3 Normal;
out float logZ;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void logDepth(inout vec4 pos){
    mat4 clip2view = inverse(projection);
    vec4 farPoint = clip2view * vec4(0,0,1,1);
    float FAR = -farPoint.z / farPoint.w;

    const float C = 0.0001;
    float FC = 1.0 / log(FAR*C + 1);
    logZ = log(max(1e-6, pos.w*C + 1.0))*FC;
    pos.z = (2.0*logZ - 1.0)*pos.w;
}

void main()
{
    vec4 worldPos = model * vec4(aPos, 1.0);
    FragPos = worldPos.xyz; 
    TexCoords = aTexCoords;
    
    mat3 normalMatrix = transpose(inverse(mat3(model)));
    Normal = normalMatrix * aNormal;
    vec4 pos = projection * view * worldPos;
    logDepth(pos);
    gl_Position = pos;
}
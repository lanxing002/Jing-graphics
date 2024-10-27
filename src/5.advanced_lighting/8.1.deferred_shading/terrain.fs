#version 330 core
layout (location = 0) out vec4 fragColor;

in vec2 TexCoords;

uniform sampler2D baseColor;

void main()
{    
    //c = (c + 1.0) * 0.5;
    //gl_FragDepth =0.0001;
    vec2 dx = dFdx(TexCoords); // 水平导数
    vec2 dy = dFdy(TexCoords); // 垂直导数
    ivec2 tsize = textureSize(baseColor, 0);

    if(TexCoords.x > 0.5)
    {
        float lod = max(length(vec2(dx.x, dy.x)) * tsize.x, length(vec2(dx.y, dy.y)) * tsize.y);
        lod = log2(lod * 20.0);
        lod = clamp(lod, 0.0, log2(float(min(tsize.x, tsize.y))));
        fragColor = textureLod(baseColor, TexCoords * 20.0, lod);
        // fragColor.rgb = vec3(lod * 20);
    }
    else 
    {

        fragColor = texture(baseColor, TexCoords * 20.0);
    }
}
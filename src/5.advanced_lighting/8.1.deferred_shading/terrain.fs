#version 330 core
layout (location = 0) out vec4 fragColor;

in vec2 TexCoords;
in float xx;

uniform sampler2D baseColor;

void main()
{    
    //c = (c + 1.0) * 0.5;
    //gl_FragDepth =0.0001;
    vec2 dx = dFdx(TexCoords); // 水平导数
    vec2 dy = dFdy(TexCoords); // 垂直导数
    float lx = sqrt(dx.x * dx.x +  dy.x * dy.x);
    float ly = sqrt(dx.y * dx.y + dy.y * dy.y);
    ivec2 tsize = textureSize(baseColor, 0);

    if(xx > 0.5)
    {
        float n = 1.0;
        vec2 dir = vec2(dx.x, dy.x);
        if(lx > ly) n = int(lx / ly); 
        else {n = int(ly / lx); dir = vec2(dx.y, dy.y);}
        n = min(n, 16.0);
        float lod = clamp(log2(min(lx * tsize.x, ly * tsize.y)), .0, log2(float(min(tsize.x, tsize.y))));
        vec4 sum = vec4(0.0);
        n -= 0.00001;
        for(float i = 0.0; i < n; i += 1.0){
            float u = TexCoords.x + dir.x * (2.0 * i - n - 1.0) / (2.0 * n + 2.0);
            float v = TexCoords.y + dir.y * (2.0 * i - n - 1.0) / (2.0 * n + 2.0);
            sum += textureLod(baseColor, vec2(u, v), lod);
        }
        sum = sum / n;
        //fragColor = textureLod(baseColor, TexCoords, lod);
        //fragColor.xyz = vec3(n / 16.0);
        fragColor.w = 1.0;
        fragColor.xyz = sum.xyz;
    }
    else 
    {
        fragColor = texture(baseColor, TexCoords);
    }
    //fragColor = texture(baseColor, TexCoords);
}
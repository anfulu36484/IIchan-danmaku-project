uniform sampler2D texture;
uniform float factor;

void main()
{
	vec2 coord = gl_TexCoord[0].st;
	
    vec4 pixel = texture2D(texture, coord);

	if (coord.x <factor)
		pixel *=3;
	
	gl_FragColor =  pixel;
}
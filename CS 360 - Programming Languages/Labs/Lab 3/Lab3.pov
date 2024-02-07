#include "textures.inc"
global_settings {ambient_light rgb 1}
camera {
    perspective
    location <20,5,5> 
    look_at <0,0,0>
}
sky_sphere {
    pigment {Blue_Sky}
}
light_source {
    <0,0,9>,
    color rgb <1,1,1>
    fade_distance 20
    fade_power 2
}
#declare Spheres = union {
    sphere {
        <0,0,-2>, 2
        pigment {color rgb <1,0,0>}
        finish {
            phong 10
            specular 3
        }
    }
    sphere {
        <0,2,2.8>, 1.4
        texture {Aluminum}
        finish {phong 10}
    }
}
  
union {
    object {Spheres}
    cone {
        <-1,-3,-10>, 0
        <0,2,3>, 1.0
        open
        texture {Aluminum}
        finish {
            diffuse 10
            specular 5
        }
    }
}

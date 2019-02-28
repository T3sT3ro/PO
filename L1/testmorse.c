#include <stdio.h>
#include "morse.h"

int main(){

    char* ala = "Ala ma kota a kot ma perfekcyjne skojarzenie i 9 serduszek";
    char* ala_encoded = morse_encode(ala);
    char* ala_decoded = morse_decode(ala_encoded);
    printf("%s -> %s -> %s\n", ala, ala_encoded, ala_decoded);

    char* garbage = ".-a.sd-sada-sd.a.-qgw.2 -3t.-sdf. q1 2- .1-.as-d.";
    char* garbage_decoded = morse_decode(garbage);
    printf("%s -> %s\n", garbage, garbage_decoded);

    char* nonalnum = "#!^#@!~@#*!@#!@#(!@)#!@ ../,',>\"{{>  @!@)#(!@!@# !@(# (!@ @#";
    char* nonalnum_encoded = morse_encode(nonalnum);
    printf("%s -> %s\n", nonalnum, nonalnum_encoded);
    return 0;
}

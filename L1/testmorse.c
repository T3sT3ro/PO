#include <stdio.h>
#include "morse.h"

int main(){

    char* ala = "Ala ma kota a kot ma perfekcyjne skojarzenie i 9 serduszek";
    char* ala_encoded = morse_encode(ala);
    char* ala_decoded = morse_decode(ala_encoded);
    printf("%s -> %s -> %s\n", ala, ala_encoded, ala_decoded);

    return 0;
}
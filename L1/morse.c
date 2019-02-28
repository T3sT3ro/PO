#include "morse.h"
#include <ctype.h>
#include <malloc.h>
#include <stdio.h>
#include <string.h>

#define MAXSIZE 5

static char *alphanum_to_morse[] = {

    "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.",  /// 0-9

    ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..",  /// A-Z

    ""  /// wrong char
};

static char morse_to_alphanum[] = {' ', ' ', 'E', 'T', 'I', 'A', 'N', 'M', 'S', 'U', 'R', 'W', 'D', 'K', 'G', 'O', 'H', 'V', 'F', ' ', 'L', ' ', 'P', 'J', 'B', 'X', 'C', 'Y', 'Z', 'Q', ' ', ' ', '5', '4', ' ', '3', ' ', ' ', ' ', '2', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '1', '6', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '7', ' ', ' ', ' ', '8', ' ', '9', '0'};

char *morse_encode(const char *str) {
    char *o_buffer = malloc(strlen(str) * (MAXSIZE + 1) + 2);
    char *o_buffer_it = o_buffer;
    for (int i = 0, c = str[0]; i < strlen(str); c = str[++i]) {
        c = (c >= '0' && c <= '9') ? c - '0' : (c >= 'a' && c <= 'z') ? c - 'a' + 10 : (c >= 'A' && c <= 'Z') ? c - 'A' + 10 : 36;
        if (c != -1)
            o_buffer_it += sprintf(o_buffer_it, "%s ", alphanum_to_morse[c]);
    }
    return realloc(o_buffer, strlen(o_buffer) + 1);
}

char *morse_decode(const char *str) {
    char *o_buffer = malloc(strlen(str) / 2 + 1);
    char *o_buffer_it = o_buffer;
    for (int i = 0, m = 1; i < strlen(str); i++) {
        if (str[i] == '.')
            m = 2 * m;
        else if (str[i] == '-')
            m = 2 * m + 1;
        
        if (str[i] != '.' && str[i] != '-' || m >= sizeof(morse_to_alphanum)/2){
            *o_buffer_it = morse_to_alphanum[m];
            ++o_buffer_it;
            m = 1;
        }
    }
    return realloc(o_buffer, strlen(o_buffer) + 1);
}

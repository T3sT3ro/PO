#ifndef MORSE_H
#define MORSE_H

/// Returns morse representation of string at buffer from charset [a-z0-9] as dots and dashes separated by whitespace.
char* morse_encode(const char*);
/// Returns character representation of the morse code formatted as a stream of dots and dashes separated with whitespace.
char* morse_decode(const char*);

#endif // MORSE_H
#include "frac.h"
#include <malloc.h>
#include <stddef.h>

#define SGN(x) ((x) < 0 ? -1 : 1)
#define ABS(x) ((x) < 0 ? -x : x)
#define SWAP(T, x, y) \
    do {              \
        T t = x;      \
        x = y;        \
        y = t;        \
    } while (0)
// constructs new frac_t pointer or returns NULL if constructor failed

static inline data_t _gcd(data_t a, data_t b) {
    while (b != 0) {
        data_t c = b;
        b = a % b;
        a = c;
    }
    return a == 0 ? 1 : ABS(a);
}

static frac_t* _normalize(frac_t* frac) {
    data_t gcd = _gcd(frac->num, frac->den);
    frac->num /= gcd;
    frac->den /= gcd;
    frac->num = SGN(frac->num) == SGN(frac->den) ? ABS(frac->num) : -ABS(frac->num);
    frac->den = ABS(frac->den);
    return frac;
}

frac_t* frac_new(data_t numerator, data_t denominator) {
    if (denominator == 0) return NULL;
    frac_t* _frac;
    if ((_frac = malloc(sizeof(frac_t))) == NULL) return NULL;
    // not for LL_MIN
    _frac->num = numerator;
    _frac->den = denominator;
    return _normalize(_frac);
}

// functions prefixed with _ override the second argument
// function returning frac_t* may return NULL upon failure
frac_t* _frac_add(const frac_t* f1, frac_t* f2) {
    data_t gcd = _gcd(f1->den, f2->den);
    f2->num = f1->num*(f2->den/gcd) + f2->num*(f1->den/gcd);
    f2->den = f1->den*(f2->den/gcd);
    return _normalize(f2);
}
frac_t* frac_add(const frac_t* f1, const frac_t* f2) {
    frac_t* COPY;
    if ((COPY = frac_new(f2->num, f2->den)) == NULL) return NULL;
    return _frac_add(f1, COPY);
}

frac_t* _frac_sub(const frac_t* f1, frac_t* f2) {
    f2->num = -(f2->num);
    return _frac_add(f1, f2);
}

frac_t* frac_sub(const frac_t* f1, const frac_t* f2) {
    frac_t* COPY;
    if ((COPY = frac_new(f2->num, f2->den)) == NULL) return NULL;
    return _frac_sub(f1, COPY);
}

frac_t* _frac_mul(const frac_t* f1, frac_t* f2) {
    data_t gcd1 = _gcd(f1->num, f2->den), gcd2 = _gcd(f1->den, f2->num);
    f2->num = (f2->num / gcd2) * (f1->num / gcd1);
    f2->den = (f2->den / gcd1) * (f1->den / gcd2);
    return _normalize(f2);
}
frac_t* frac_mul(const frac_t* f1, const frac_t* f2) {
    frac_t* COPY;
    if ((COPY = frac_new(f2->num, f2->den)) == NULL) return NULL;
    return _frac_mul(f1, COPY);
}

frac_t* _frac_div(const frac_t* f1, frac_t* f2) {
    if (f2->num == 0) return NULL;
    SWAP(data_t, f2->num, f2->den);
    return _frac_mul(f1, f2);
}
frac_t* frac_div(const frac_t* f1, const frac_t* f2) {
    if (f2->num == 0) return NULL;
    frac_t* COPY;
    if ((COPY = frac_new(f2->num, f2->den)) == NULL) return NULL;
    return _frac_div(f1, COPY);
}

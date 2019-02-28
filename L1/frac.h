#ifndef FRAC_H
#define FRAC_H

typedef long long data_t;

typedef struct {
    data_t num, den;
} frac_t;

// constructs new frac_t pointer or returns NULL if constructor failed
frac_t* frac_new(data_t, data_t);

// functions prefixed with _ override the second argument, without - create new fraction
// function creating new fraction may lead to memory leak if pointer is not freed.
// function returning frac_t* may return NULL upon failure
frac_t* _frac_add(const frac_t*, frac_t*);
frac_t* frac_add(const frac_t*, const frac_t*);

frac_t* _frac_sub(const frac_t*, frac_t*);
frac_t* frac_sub(const frac_t*, const frac_t*);

frac_t* _frac_mul(const frac_t*, frac_t*);
frac_t* frac_mul(const frac_t*, const frac_t*);

frac_t* _frac_div(const frac_t*, frac_t*);
frac_t* frac_div(const frac_t*, const frac_t*);

#endif  // FRAC_H
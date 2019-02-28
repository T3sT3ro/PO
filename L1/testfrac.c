#include <stdio.h>
#include "frac.h"

#define pff(frac)                                  \
    do {                                           \
        frac_t* t = frac;                          \
        printf("(%d)/(%d)\n", t->num, t->den); \
    } while (0)

int main() {
    frac_t* f1 = frac_new(1, 3);
    frac_t* f2 = frac_new(1, 4);

    printf("f1, f2:\n");
    pff(f1);
    pff(f2);

    printf("+, -, *, / with new copies:\n");
    pff(frac_add(f1, f2));  // mem leak!
    pff(frac_sub(f1, f2));  // mem leak!
    pff(frac_mul(f1, f2));  // mem leak!
    pff(frac_div(f1, f2));  // mem leak!

    printf("f1, f2:\n");
    pff(f1);
    pff(f2);

    printf("+, -, *, / in place:\n");
    pff(_frac_add(f1, f2));  // mem leak!
    pff(_frac_sub(f1, f2));  // mem leak!
    pff(_frac_mul(f1, f2));  // mem leak!
    pff(_frac_div(f1, f2));  // mem leak!

    printf("f1, f2:\n");
    pff(f1);
    pff(f2);
    
    return 0;
}

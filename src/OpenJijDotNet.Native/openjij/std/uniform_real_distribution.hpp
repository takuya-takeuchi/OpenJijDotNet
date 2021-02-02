#ifndef _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_
#define _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::uniform_real_distribution<__TYPE__>* std_uniform_real_distribution_##__TYPENAME__##_new(__TYPE__ a, __TYPE__ b)\
{\
    return new std::uniform_real_distribution<__TYPE__>(a, b);\
}\
\
DLLEXPORT void std_uniform_real_distribution_##__TYPENAME__##_delete(std::uniform_real_distribution<__TYPE__> *uniform_real_distribution)\
{\
    delete uniform_real_distribution;\
}\

#pragma endregion template

// primitives
MAKE_FUNC(double, double)

#endif // _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_

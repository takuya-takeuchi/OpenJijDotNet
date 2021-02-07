#ifndef _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_
#define _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <utility/random.hpp>

#pragma region template

#define MAKE_UNIFORM_REAL_DISTRIBUTION_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::uniform_real_distribution<__TYPE__>* std_uniform_real_distribution_##__TYPENAME__##_new(__TYPE__ a, __TYPE__ b)\
{\
    return new std::uniform_real_distribution<__TYPE__>(a, b);\
}\
\
DLLEXPORT void std_uniform_real_distribution_##__TYPENAME__##_delete(std::uniform_real_distribution<__TYPE__> *uniform_real_distribution)\
{\
    delete uniform_real_distribution;\
}\

#define MAKE_UNIFORM_REAL_DISTRIBUTION_OPERATOR_FUNC(__TYPE__, __TYPENAME__, __RNGTYPE__, __RNGNAME__)\
DLLEXPORT __TYPE__ std_uniform_real_distribution_##__TYPENAME__##_##__RNGNAME__##_operator(std::uniform_real_distribution<__TYPE__> *uniform_real_distribution,\
                                                                                           __RNGTYPE__* rng)\
{\
    auto& r = *rng;\
    return uniform_real_distribution->operator()(r);\
}\

#pragma endregion template

// primitives
MAKE_UNIFORM_REAL_DISTRIBUTION_FUNC(double, double)
MAKE_UNIFORM_REAL_DISTRIBUTION_OPERATOR_FUNC(double, double, openjij::utility::Xorshift, xorshift)

#endif // _CPP_STD_UNIFORM_REAL_DISTRIBUTION_H_

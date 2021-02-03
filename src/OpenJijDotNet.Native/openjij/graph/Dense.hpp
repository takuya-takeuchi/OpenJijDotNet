#ifndef _CPP_GRAPH_DENSE_H_
#define _CPP_GRAPH_DENSE_H_ 1

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/dense.hpp>

using namespace openjij;

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT graph::Dense<__TYPE__>* graph_Dense_##__TYPENAME__##_new(const std::size_t num_spins)\
{\
    return new graph::Dense<__TYPE__>(num_spins);\
}\
\
DLLEXPORT void graph_Dense_##__TYPENAME__##_delete(graph::Dense<__TYPE__> *dense)\
{\
    delete dense;\
}\
DLLEXPORT int32_t graph_Dense_##__TYPENAME__##_get_num_spins(graph::Dense<__TYPE__> *dense, std::size_t* num_spins)\
{\
    *num_spins = dense->get_num_spins();\
    return ERR_OK;\
}\

#pragma endregion template

// primitives
MAKE_FUNC(double, double)

#endif // _CPP_GRAPH_DENSE_H_

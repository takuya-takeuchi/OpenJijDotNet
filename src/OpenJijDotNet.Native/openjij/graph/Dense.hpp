#ifndef _CPP_GRAPH_DENSE_H_
#define _CPP_GRAPH_DENSE_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/dense.hpp>

using namespace openjij;

#pragma region template

#define MAKE_DENSE_FUNC(__TYPE__, __TYPENAME__)\
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
\
DLLEXPORT int32_t graph_Dense_##__TYPENAME__##_get_J(graph::Dense<__TYPE__> *dense, const uint32_t i, const uint32_t j, __TYPE__* value)\
{\
    *value = dense->J(i, j);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Dense_##__TYPENAME__##_set_J(graph::Dense<__TYPE__> *dense, const uint32_t i, const uint32_t j, const __TYPE__ value)\
{\
    dense->J(i, j) = value;\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Dense_##__TYPENAME__##_get_h(graph::Dense<__TYPE__> *dense, const uint32_t i, __TYPE__* value)\
{\
    *value = dense->h(i);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Dense_##__TYPENAME__##_set_h(graph::Dense<__TYPE__> *dense, const uint32_t i, const __TYPE__ value)\
{\
    dense->h(i) = value;\
    return ERR_OK;\
}\

#pragma endregion template

// primitives
MAKE_DENSE_FUNC(double, double)

#endif // _CPP_GRAPH_DENSE_H_

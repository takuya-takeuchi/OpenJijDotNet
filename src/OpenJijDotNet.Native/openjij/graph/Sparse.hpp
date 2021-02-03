#ifndef _CPP_GRAPH_SPARSE_H_
#define _CPP_GRAPH_SPARSE_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/sparse.hpp>

using namespace openjij;

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT graph::Sparse<__TYPE__>* graph_Sparse_##__TYPENAME__##_new(const std::size_t num_spins)\
{\
    return new graph::Sparse<__TYPE__>(num_spins);\
}\
\
DLLEXPORT void graph_Sparse_##__TYPENAME__##_delete(graph::Sparse<__TYPE__> *sparse)\
{\
    delete sparse;\
}\
DLLEXPORT int32_t graph_Sparse_##__TYPENAME__##_get_num_spins(graph::Sparse<__TYPE__> *sparse, std::size_t* num_spins)\
{\
    *num_spins = sparse->get_num_spins();\
    return ERR_OK;\
}\

#pragma endregion template

// primitives
MAKE_FUNC(double, double)

#endif // _CPP_GRAPH_DENSE_H_

#ifndef _CPP_SYSTEM_TRANSVERSE_ISING_H_
#define _CPP_SYSTEM_TRANSVERSE_ISING_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <graph/dense.hpp>
#include <graph/sparse.hpp>
#include <system/transverse_ising.hpp>

#pragma region template

#define MAKE_TRANSVERSE_ISING_FUNC(__TYPE__, __TYPENAME__, __GRAPHTYPE__, __GRAPHNAME__)\
DLLEXPORT openjij::system::TransverseIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>>* system_TransverseIsing_##__GRAPHNAME__##_##__TYPENAME__##_new(openjij::graph::Spins* init_spin, \
                                                                                                                                                   openjij::graph::__GRAPHTYPE__<__TYPE__>* init_interaction)\
{\
    const auto& spins = *init_spin;\
    const auto& ising = *init_interaction;\
    return new openjij::system::TransverseIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>>(spins, ising);\
}\
\
DLLEXPORT void system_TransverseIsing_##__GRAPHNAME__##_##__TYPENAME__##_delete(openjij::system::TransverseIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>> *ising)\
{\
    delete ising;\
}\

#pragma endregion template

// primitives
MAKE_TRANSVERSE_ISING_FUNC(double, double, Dense, Dense)

#endif // _CPP_GRAPH_DENSE_H_

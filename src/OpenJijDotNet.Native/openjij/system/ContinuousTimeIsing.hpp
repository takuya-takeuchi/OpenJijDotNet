#ifndef _CPP_SYSTEM_CONTINUOUSTIME_ISING_H_
#define _CPP_SYSTEM_CONTINUOUSTIME_ISING_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <graph/dense.hpp>
#include <graph/sparse.hpp>
#include <system/continuous_time_ising.hpp>

#pragma region template

#define MAKE_CONTINUOUSTIME_ISING_FUNC(__TYPE__, __TYPENAME__, __GRAPHTYPE__, __GRAPHNAME__)\
DLLEXPORT openjij::system::ContinuousTimeIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>>* system_ContinuousTimeIsing_##__GRAPHNAME__##_##__TYPENAME__##_new(openjij::graph::Spins* init_spin, \
                                                                                                                                                           openjij::graph::__GRAPHTYPE__<__TYPE__>* init_interaction, \
                                                                                                                                                           const double gamma)\
{\
    const auto& spins = *init_spin;\
    const auto& ising = *init_interaction;\
    return new openjij::system::ContinuousTimeIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>>(spins, ising, gamma);\
}\
\
DLLEXPORT void system_ContinuousTimeIsing_##__GRAPHNAME__##_##__TYPENAME__##_delete(openjij::system::ContinuousTimeIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>> *ising)\
{\
    delete ising;\
}\
\
DLLEXPORT void system_ContinuousTimeIsing_##__GRAPHNAME__##_##__TYPENAME__##_reset_spins(openjij::system::ContinuousTimeIsing<openjij::graph::__GRAPHTYPE__<__TYPE__>> *ising,\
                                                                                         openjij::graph::Spins* spins)\
{\
    const auto& s = *spins;\
    ising->reset_spins(s);\
}\

#pragma endregion template

// primitives
MAKE_CONTINUOUSTIME_ISING_FUNC(double, double, Sparse, Sparse)

#endif // _CPP_GRAPH_DENSE_H_

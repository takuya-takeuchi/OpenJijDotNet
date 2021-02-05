#ifndef _CPP_RESULT_GETSOLUTION_H_
#define _CPP_RESULT_GETSOLUTION_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <result/get_solution.hpp>
#include <graph/dense.hpp>
#include <graph/sparse.hpp>
#include <system/classical_ising.hpp>
#include <system/continuous_time_ising.hpp>
#include <system/transverse_ising.hpp>

#pragma region template

#define get_solution_template(error, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, ...) \
{\
    const auto& system = *static_cast<openjij::system::__ISINGTYPE__<openjij::graph::__GRAPHTYPE__<__FLOATTYPE__>>*>(ising);\
    const auto& ret = openjij::result::get_solution(system);\
    auto tmp = new openjij::graph::Spins(ret.size());\
    for (auto index = 0; index < ret.size(); index++)\
        tmp->operator[](index) = ret[index];\
    *spins = tmp;\
}

#define get_solution_float_template(error, __ISINGTYPE__, __GRAPHTYPE__, ...) \
switch(float_type)\
{\
    case ::float_types::Double:\
        get_solution_template(error, __ISINGTYPE__, __GRAPHTYPE__, double, __VA_ARGS__);\
        break;\
    case ::float_types::Float:\
        get_solution_template(error, __ISINGTYPE__, __GRAPHTYPE__, float, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_FLOAT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define get_solution_graph_template(error, __ISINGTYPE__, ...) \
switch(graph_type)\
{\
    case ::graph_types::Dense:\
        get_solution_float_template(error, __ISINGTYPE__, Dense, __VA_ARGS__);\
        break;\
    case ::graph_types::Sparse:\
        get_solution_float_template(error, __ISINGTYPE__, Sparse, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_GRAPH_TYPE_NOT_SUPPORT;\
        break;\
}\

#define get_solution(error, ...) \
switch(ising_type)\
{\
    case ::ising_types::Classical:\
        get_solution_graph_template(error, ClassicalIsing, __VA_ARGS__);\
        break;\
    case ::ising_types::ContinuousTime:\
        get_solution_graph_template(error, ContinuousTimeIsing, __VA_ARGS__);\
        break;\
    case ::ising_types::Transverse:\
        get_solution_graph_template(error, ContinuousTimeIsing, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_ISING_TYPE_NOT_SUPPORT;\
        break;\
}

#pragma endregion template

using namespace openjij;

DLLEXPORT int32_t result_get_solution(void* ising,
                                      const ising_types ising_type,
                                      const graph_types graph_type,
                                      const float_types float_type,
                                      openjij::graph::Spins** spins)
{
    int error = ERR_OK;

    get_solution(error,
                 ising_type,
                 graph_type,
                 float_type,
                 ising,
                 spins);

    return error;
}

#endif // _CPP_ALGORITHM_ALGORITHM_H_

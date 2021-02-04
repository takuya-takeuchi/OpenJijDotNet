#ifndef _CPP_RESULT_GETSOLUTION_H_
#define _CPP_RESULT_GETSOLUTION_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/all.hpp>
#include <system/all.hpp>

#pragma region template

#define run_template(error, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, ...) \
{\
    auto& system = *static_cast<openjij::system::__ISINGTYPE__<openjij::graph::__GRAPHTYPE__<__FLOATTYPE__>>*>(ising);\
    const auto& ret = openjij::result::get_solution(system);\
    auto tmp = new Spins(ret.size());\
    for (auto index = 0; index < ret.size(); index++)\
        tmp->operator[](index) = ret[index];\
    *spins = tmp;\
}

#define float_template(error, __UPDATERTYPE__, __GRAPHTYPE__, ...) \
switch(float_type)\
{\
    case ::float_types::Double:\
        run_template(error, __ISINGTYPE__, __GRAPHTYPE__, double, __VA_ARGS__);\
        break;\
    case ::float_types::Float:\
        run_template(error, __ISINGTYPE__, __GRAPHTYPE__, float, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_FLOAT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define graph_template(error, __ISINGTYPE__, ...) \
switch(graph_type)\
{\
    case ::graph_types::Dense:\
        float_template(error, __ISINGTYPE__, Dense, __VA_ARGS__);\
        break;\
    case ::graph_types::Sparse:\
        float_template(error, __ISINGTYPE__, Sparse, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_GRAPH_TYPE_NOT_SUPPORT;\
        break;\
}\

#define run(error, ...) \
switch(updater_type)\
{\
    case ::ising_types::Classical:\
        graph_template(error, ClassicalIsing, __VA_ARGS__);\
        break;\
    case ::ising_types::ContinuousTime:\
        graph_template(error, ContinuousTimeIsing, __VA_ARGS__);\
        break;\
    case ::ising_types::Transverse:\
        graph_template(error, ContinuousTimeIsing, __VA_ARGS__);\
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

    run(error,
        ising,
        ising_type,
        graph_type,
        float_type,
        spins);

    return error;
}

#endif // _CPP_ALGORITHM_ALGORITHM_H_

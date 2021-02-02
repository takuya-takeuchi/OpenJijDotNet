#ifndef _CPP_ALGORITHM_ALGORITHM_H_
#define _CPP_ALGORITHM_ALGORITHM_H_

#include "../export.h"
#include "../shared.h"
#include <random>

#include <algorithm/algorithm.hpp>
#include <updater/all.hpp>

using namespace openjij;

#pragma region template

#define run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
const auto& i = *static_cast<__ISINGTYPE__<__GRAPHTYPE__<__FLOATTYPE__>>>(ising);\
const auto& rng = *random_number_engine;\
const auto& s = *static_cast<__SCHEDULETYPE__>(schedule_list);\
algorithm::Algorithm<__UPDATERTYPE__>::run(i, rng, s);\

#define schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(schedule_list_type)\
{\
    case schedule_list_type::Classical:\
        run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, ClassicalScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    case schedule_list_type::Transverse:\
        run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, TransverseFieldScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_MATRIX_ELEMENT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(float_type)\
{\
    case float_type::Float:\
        schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, float, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    case float_type::Double:\
        schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, double, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_MATRIX_ELEMENT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define graph_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(graph_type)\
{\
    case graph_type::Dense:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, graph::Dense, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    case graph_type::Sparse:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, graph::Sparse, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_MATRIX_ELEMENT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define ising_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(ising_type)\
{\
    case ising_type::Classical:\
        graph_template(error, system::ClassicalIsing, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    case ising_type::ContinuousTime:\
        graph_template(error, system::ContinuousTimeIsing, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    case ising_type::Transverse:\
        graph_template(error, system::TransverseIsing, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_MATRIX_ELEMENT_TYPE_NOT_SUPPORT;\
        break;\
}

#pragma endregion template

using namespace openjij;

DLLEXPORT int32_t algorithm_Algorithm_run(const int32_t updater_type,
                                          void* ising,
                                          const int32_t ising_type,
                                          const int32_t graph_type,
                                          const int32_t float_type,
                                          std::mt19937* random_number_engine,
                                          void* schedule_list,
                                          const int32_t schedule_list_type)
{
    return ERR_OK;
}

#endif
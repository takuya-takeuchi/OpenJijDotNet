#ifndef _CPP_ALGORITHM_ALGORITHM_H_
#define _CPP_ALGORITHM_ALGORITHM_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <algorithm/algorithm.hpp>
#include <system/classical_ising.hpp>
#include <system/transverse_ising.hpp>
#include <updater/single_spin_flip.hpp>
#include <utility/schedule_list.hpp>

#pragma region template

#define run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __GRAPHTYPE__, __FLOATTYPE__, __RNG__, ...) \
{\
    auto& i = *static_cast<openjij::system::__ISINGTYPE__<openjij::graph::__GRAPHTYPE__<__FLOATTYPE__>>*>(ising);\
    auto& rng = *random_number_engine;\
    auto& s = *static_cast<openjij::utility::__SCHEDULETYPE__*>(schedule_list);\
    algorithm::Algorithm<openjij::updater::__UPDATERTYPE__>::run(i, rng, s);\
}

#define float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __GRAPHTYPE__, __RNG__, ...) \
switch(float_type)\
{\
    case ::float_types::Double:\
        run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __GRAPHTYPE__, double, __RNG__, __VA_ARGS__);\
        break;\
    case ::float_types::Float:\
        run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __GRAPHTYPE__, float, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_FLOAT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define graph_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(graph_type)\
{\
    case ::graph_types::Dense:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, Dense, __RNG__, __VA_ARGS__);\
        break;\
    case ::graph_types::Sparse:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, Sparse, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_GRAPH_TYPE_NOT_SUPPORT;\
        break;\
}\

#define sparse_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
switch(graph_type)\
{\
    case ::graph_types::Sparse:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __SCHEDULETYPE__, Sparse, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_GRAPH_TYPE_NOT_SUPPORT;\
        break;\
}\

#define SingleSpinFlip_run(error, ...) \
switch(ising_type)\
{\
    case ::ising_types::Classical:\
        graph_template(error, SingleSpinFlip, ClassicalIsing, ClassicalScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    case ::ising_types::Transverse:\
        graph_template(error, SingleSpinFlip, TransverseIsing, TransverseFieldScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_ISING_TYPE_NOT_SUPPORT;\
        break;\
}

#define SwendsenWang_run(error, ...) \
switch(ising_type)\
{\
    case ::ising_types::Classical:\
        sparse_template(error, SwendsenWang, ClassicalIsing, ClassicalScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_ISING_TYPE_NOT_SUPPORT;\
        break;\
}

#define ContinuousTimeSwendsenWang_run(error, ...) \
switch(ising_type)\
{\
    case ::ising_types::Transverse:\
        sparse_template(error, ContinuousTimeSwendsenWang, ContinuousTimeIsing, TransverseFieldScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_ISING_TYPE_NOT_SUPPORT;\
        break;\
}

#define run(error, ...) \
switch(updater_type)\
{\
    case ::updater_types::SingleSpinFlip:\
        SingleSpinFlip_run(error, __VA_ARGS__);\
        break;\
    case ::updater_types::SwendsenWang:\
        SwendsenWang_run(error, __VA_ARGS__);\
        break;\
    case ::updater_types::ContinuousTimeSwendsenWang:\
        ContinuousTimeSwendsenWang_run(error, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_UPDATER_TYPE_NOT_SUPPORT;\
        break;\
}

#pragma endregion template

using namespace openjij;

DLLEXPORT int32_t algorithm_Algorithm_run(const updater_types updater_type,
                                          void* ising,
                                          const ising_types ising_type,
                                          const graph_types graph_type,
                                          const float_types float_type,
                                          std::mt19937* random_number_engine,
                                          void* schedule_list)
{
    int error = ERR_OK;

    run(error,
        updater_type,
        ising,
        ising_type,
        graph_type,
        float_type,
        random_number_engine,
        schedule_list);

    return error;
}

#endif // _CPP_ALGORITHM_ALGORITHM_H_

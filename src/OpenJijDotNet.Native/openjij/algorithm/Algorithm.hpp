#ifndef _CPP_ALGORITHM_ALGORITHM_H_
#define _CPP_ALGORITHM_ALGORITHM_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <algorithm/algorithm.hpp>
#include <system/classical_ising.hpp>
#include <system/system.hpp>
#include <system/transverse_ising.hpp>
#include <updater/single_spin_flip.hpp>
#include <utility/schedule_list.hpp>

using namespace openjij;
using namespace openjij::system;
using namespace openjij::utility;

#pragma region template

#define run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
{\
    auto& i = *static_cast<openjij::system::__ISINGTYPE__<openjij::graph::__GRAPHTYPE__<__FLOATTYPE__>>*>(ising);\
    auto& rng = *random_number_engine;\
    auto& s = *static_cast<openjij::utility::__SCHEDULETYPE__*>(schedule_list);\
    algorithm::Algorithm<openjij::updater::__UPDATERTYPE__>::run(i, rng, s);\
}

// #define run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __SCHEDULETYPE__, __RNG__, ...) \
// {\
//     constexpr std::size_t N = 500;\
//     auto dense = graph::Dense<double>(N);\
//     auto rand_engine = std::mt19937(0x1234);\
//     auto system = system::make_classical_ising(dense.gen_spin(rand_engine), dense);\
//     auto schedule_list = utility::make_classical_schedule_list(0.1, 100, 10, 200);\
//     algorithm::Algorithm<updater::SingleSpinFlip>::run(system, rand_engine, schedule_list);\
// }


#define schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, __RNG__, ...) \
switch(schedule_list_type)\
{\
    case ::schedule_list_types::Classical:\
        run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, ClassicalScheduleList, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_SCHEDULELIST_TYPE_NOT_SUPPORT;\
        break;\
}\
    // case ::schedule_list_types::Transverse:\
    //     run_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __FLOATTYPE__, TransverseFieldScheduleList, __RNG__, __VA_ARGS__);\
    //     break;\

#define float_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, __RNG__, ...) \
switch(float_type)\
{\
    case ::float_types::Double:\
        schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, double, __RNG__, __VA_ARGS__);\
        break;\
    case ::float_types::Float:\
        schedule_list_template(error, __UPDATERTYPE__, __ISINGTYPE__, __GRAPHTYPE__, float, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_FLOAT_TYPE_NOT_SUPPORT;\
        break;\
}\

#define graph_template(error, __UPDATERTYPE__, __ISINGTYPE__, __RNG__, ...) \
switch(graph_type)\
{\
    case ::graph_types::Dense:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, Dense, __RNG__, __VA_ARGS__);\
        break;\
    case ::graph_types::Sparse:\
        float_template(error, __UPDATERTYPE__, __ISINGTYPE__, Sparse, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_GRAPH_TYPE_NOT_SUPPORT;\
        break;\
}\

#define SingleSpinFlip_run(error, ...) \
switch(ising_type)\
{\
    case ::ising_types::Classical:\
        graph_template(error, SingleSpinFlip, ClassicalIsing, __RNG__, __VA_ARGS__);\
        break;\
    default:\
        error = ERR_ISING_TYPE_NOT_SUPPORT;\
        break;\
}
    // case ::ising_types::Transverse:\
    //     graph_template(error, SingleSpinFlip, TransverseIsing, __RNG__, __VA_ARGS__);\
    //     break;\

#pragma endregion template

using namespace openjij;

DLLEXPORT int32_t algorithm_Algorithm_SingleSpinFlip_run(void* ising,
                                                         const ising_types ising_type,
                                                         const graph_types graph_type,
                                                         const float_types float_type,
                                                         std::mt19937* random_number_engine,
                                                         void* schedule_list,
                                                         const schedule_list_types schedule_list_type)
{
    int error = ERR_OK;

    SingleSpinFlip_run(error,
                       ising,
                       ising_type,
                       graph_type,
                       float_type,
                       random_number_engine,
                       schedule_list,
                       schedule_list_type);

    return error;
}

#endif // _CPP_ALGORITHM_ALGORITHM_H_

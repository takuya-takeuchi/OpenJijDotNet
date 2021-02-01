#ifndef _CPP_GRAPH_DENSE_H_
#define _CPP_GRAPH_DENSE_H_

#include "../export.h"
#include "../shared.h"
#include <random>

#include <graph/all.hpp>
#include <system/all.hpp>
#include <updater/all.hpp>
#include <algorithm/all.hpp>
#include <result/all.hpp>
#include <utility/schedule_list.hpp>

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

#endif
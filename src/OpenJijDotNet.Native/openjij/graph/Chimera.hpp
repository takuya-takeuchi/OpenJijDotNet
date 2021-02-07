#ifndef _CPP_GRAPH_CHIMERA_H_
#define _CPP_GRAPH_CHIMERA_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/chimera.hpp>

using namespace openjij;

#pragma region template

#define MAKE_CHIMERA_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT graph::Chimera<__TYPE__>* graph_Chimera_##__TYPENAME__##_new(const std::size_t num_row, \
                                                                       const std::size_t num_column, \
                                                                       const __TYPE__ init_val)\
{\
    return new graph::Chimera<__TYPE__>(num_row, num_column, init_val);\
}\
\
DLLEXPORT void graph_Chimera_##__TYPENAME__##_delete(graph::Chimera<__TYPE__> *chimera)\
{\
    delete chimera;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_num_spins(graph::Chimera<__TYPE__> *chimera, \
                                                               std::size_t* num_spins)\
{\
    *num_spins = chimera->get_num_spins();\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_J(graph::Chimera<__TYPE__> *chimera, \
                                                       const uint32_t r, \
                                                       const uint32_t c, \
                                                       const uint32_t i, \
                                                       const graph::ChimeraDir dir, \
                                                       __TYPE__* value)\
{\
    *value = chimera->J(r, c, i, dir);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_set_J(graph::Chimera<__TYPE__> *chimera, \
                                                       const uint32_t r, \
                                                       const uint32_t c, \
                                                       const uint32_t i, \
                                                       const graph::ChimeraDir dir, \
                                                       const __TYPE__ value)\
{\
    chimera->J(r, c, i, dir) = value;\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_H(graph::Chimera<__TYPE__> *chimera, \
                                                       const uint32_t r, \
                                                       const uint32_t c, \
                                                       const uint32_t i, \
                                                       __TYPE__* value)\
{\
    *value = chimera->h(r, c, i);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_set_H(graph::Chimera<__TYPE__> *chimera, \
                                                       const uint32_t r, \
                                                       const uint32_t c, \
                                                       const uint32_t i, \
                                                       const __TYPE__ value)\
{\
    chimera->h(r, c, i) = value;\
    return ERR_OK;\
}\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_num_row(graph::Chimera<__TYPE__> *chimera, uint32_t* value)\
{\
    *value = chimera->get_num_row();\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_num_column(graph::Chimera<__TYPE__> *chimera, uint32_t* value)\
{\
    *value = chimera->get_num_column();\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_num_in_chimera(graph::Chimera<__TYPE__> *chimera, uint32_t* value)\
{\
    *value = chimera->get_num_in_chimera();\
    return ERR_OK;\
}\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_get_spin(graph::Chimera<__TYPE__> *chimera, \
                                                          graph::Spins* spins, \
                                                          const uint32_t r, \
                                                          const uint32_t c, \
                                                          const uint32_t i, \
                                                          graph::Spin* value)\
{\
    const auto& tmp = *spins;\
    *value = chimera->spin(tmp, r, c, i);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Chimera_##__TYPENAME__##_set_spin(graph::Chimera<__TYPE__> *chimera, \
                                                          graph::Spins* spins, \
                                                          const uint32_t r, \
                                                          const uint32_t c, \
                                                          const uint32_t i, \
                                                          const graph::Spin value)\
{\
    auto& tmp = *spins;\
    chimera->spin(tmp, r, c, i) = value;\
    return ERR_OK;\
}\

#pragma endregion template

// primitives
MAKE_CHIMERA_FUNC(double, double)

#endif // _CPP_GRAPH_CHIMERA_H_

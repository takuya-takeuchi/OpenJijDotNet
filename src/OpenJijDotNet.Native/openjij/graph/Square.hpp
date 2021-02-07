#ifndef _CPP_GRAPH_SQUARE_H_
#define _CPP_GRAPH_SQUARE_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/square.hpp>

using namespace openjij;

#pragma region template

#define MAKE_SQUARE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT graph::Square<__TYPE__>* graph_Square_##__TYPENAME__##_new(const std::size_t num_row, \
                                                                     const std::size_t num_column, \
                                                                     const __TYPE__ init_val)\
{\
    return new graph::Square<__TYPE__>(num_row, num_column, init_val);\
}\
\
DLLEXPORT void graph_Square_##__TYPENAME__##_delete(graph::Square<__TYPE__> *square)\
{\
    delete square;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_num_spins(graph::Square<__TYPE__> *square, std::size_t* num_spins)\
{\
    *num_spins = square->get_num_spins();\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_J(graph::Square<__TYPE__> *square, \
                                                      const uint32_t r, \
                                                      const uint32_t c, \
                                                      const graph::Dir dir, \
                                                      __TYPE__* value)\
{\
    *value = square->J(r, c, dir);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_set_J(graph::Square<__TYPE__> *square, \
                                                      const uint32_t r, \
                                                      const uint32_t c, \
                                                      const graph::Dir dir, \
                                                      const __TYPE__ value)\
{\
    square->J(r, c, dir) = value;\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_H(graph::Square<__TYPE__> *square, \
                                                      const uint32_t r, \
                                                      const uint32_t c, \
                                                      __TYPE__* value)\
{\
    *value = square->h(r, c);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_set_H(graph::Square<__TYPE__> *square, \
                                                      const uint32_t r, \
                                                      const uint32_t c, \
                                                      const __TYPE__ value)\
{\
    square->h(r, c) = value;\
    return ERR_OK;\
}\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_num_row(graph::Square<__TYPE__> *square, uint32_t* value)\
{\
    *value = square->get_num_row();\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_num_column(graph::Square<__TYPE__> *square, uint32_t* value)\
{\
    *value = square->get_num_column();\
    return ERR_OK;\
}\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_get_spin(graph::Square<__TYPE__> *square, \
                                                         graph::Spins* spins, \
                                                         const uint32_t r, \
                                                         const uint32_t c, \
                                                         graph::Spin* value)\
{\
    const auto& tmp = *spins;\
    *value = square->spin(tmp, r, c);\
    return ERR_OK;\
}\
\
DLLEXPORT int32_t graph_Square_##__TYPENAME__##_set_spin(graph::Square<__TYPE__> *square, \
                                                         graph::Spins* spins, \
                                                         const uint32_t r, \
                                                         const uint32_t c, \
                                                         const graph::Spin value)\
{\
    auto& tmp = *spins;\
    square->spin(tmp, r, c) = value;\
    return ERR_OK;\
}\

#pragma endregion template

// primitives
MAKE_SQUARE_FUNC(double, double)

#endif // _CPP_GRAPH_SQUARE_H_

#ifndef _CPP_GRAPH_GRAPH_H_
#define _CPP_GRAPH_GRAPH_H_ 1

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/graph.hpp>

using namespace openjij;
using namespace openjij::graph;

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT Spins* graph_Graph_gen_spin__##__TYPENAME__(Graph* graph, __TYPE__* random_numder_engine)\
{\
    auto& rne = *random_numder_engine;\
    const auto spins = graph->gen_spin(rne);\
    auto ret = new Spins(spins.size());\
    for (auto index = 0; index < spins.size(); index++)\
        ret->operator[](index) = spins[index];\
    return ret;\
}\

#pragma endregion template

MAKE_FUNC(std::mt19937, mt19937)

#endif // _CPP_GRAPH_GRAPH_H_
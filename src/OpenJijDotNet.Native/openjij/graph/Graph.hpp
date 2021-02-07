#ifndef _CPP_GRAPH_GRAPH_H_
#define _CPP_GRAPH_GRAPH_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <graph/graph.hpp>

using namespace openjij;

#pragma region template

#define MAKE_GRAPH_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT openjij::graph::Spins* graph_Graph_gen_spin_##__TYPENAME__(openjij::graph::Graph* graph, __TYPE__* random_numder_engine)\
{\
    auto& rne = *random_numder_engine;\
    const auto spins = graph->gen_spin(rne);\
    auto ret = new openjij::graph::Spins(spins.begin(), spins.begin() + spins.size());\
    return ret;\
}\

#pragma endregion template

MAKE_GRAPH_FUNC(std::mt19937, mt19937)

#endif // _CPP_GRAPH_GRAPH_H_

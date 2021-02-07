#ifndef _CPP_UTILITY_XORSHIFT_H_
#define _CPP_UTILITY_XORSHIFT_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <utility/random.hpp>

using namespace openjij;
using namespace openjij::utility;

DLLEXPORT Xorshift* utility_Xorshift_new()
{
    return new Xorshift();
}

DLLEXPORT Xorshift* utility_Xorshift_new2(const uint32_t s)
{
    return new Xorshift(s);
}

DLLEXPORT void utility_Xorshift_delete(Xorshift* xorshift)
{
    delete xorshift;
}

DLLEXPORT uint32_t utility_Xorshift_operator(Xorshift* xorshift)
{
    return xorshift->operator()();
}

DLLEXPORT uint32_t utility_Xorshift_min()
{
    return Xorshift::min();
}

DLLEXPORT uint32_t utility_Xorshift_max()
{
    return Xorshift::max();
}

#endif // _CPP_UTILITY_XORSHIFT_H_

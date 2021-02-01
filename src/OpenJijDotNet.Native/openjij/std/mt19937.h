#ifndef _CPP_STD_MT19937_H_
#define _CPP_STD_MT19937_H_

#include "../export.h"
#include "../shared.h"
#include <random>

DLLEXPORT std::mt19937* std_mt19937_new(std::random_device* device)
{
    return new std::mt19937(device->operator()());
}

DLLEXPORT void std_mt19937_delete(std::mt19937* device)
{
    delete device;
}

#endif
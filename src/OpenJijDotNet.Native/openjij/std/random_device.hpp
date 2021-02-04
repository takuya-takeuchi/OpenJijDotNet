#ifndef _CPP_STD_RANDOMDEVICE_H_
#define _CPP_STD_RANDOMDEVICE_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

DLLEXPORT std::random_device* std_random_device_new()
{
    return new std::random_device;
}

DLLEXPORT void std_random_device_delete(std::random_device* device)
{
    delete device;
}

#endif // _CPP_STD_RANDOMDEVICE_H_

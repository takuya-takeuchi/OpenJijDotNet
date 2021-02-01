#ifndef _CPPSTD_RANDOMDEVICE_H_
#define _CPPSTD_RANDOMDEVICE_H_

#include "../export.h"
#include "../shared.h"
#include <random>

DLLEXPORT std::random_device* std_random_device_new()
{
    return new std::random_device;
}

DLLEXPORT void std_random_device_delete(std::random_device* device)
{
    delete device;
}

#endif
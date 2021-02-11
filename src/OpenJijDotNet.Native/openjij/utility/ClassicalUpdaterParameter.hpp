#ifndef _CPP_UTILITY_CLASSICAL_UPDATER_PARAMETER_H_
#define _CPP_UTILITY_CLASSICAL_UPDATER_PARAMETER_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <utility/schedule_list.hpp>

using namespace openjij;
using namespace openjij::utility;

DLLEXPORT ClassicalUpdaterParameter* utility_ClassicalUpdaterParameter_new(double beta)
{
    return new ClassicalUpdaterParameter(beta);
}

DLLEXPORT void utility_ClassicalUpdaterParameter_delete(ClassicalUpdaterParameter* parameter)
{
    delete parameter;
}

DLLEXPORT double utility_ClassicalUpdaterParameter_get_tuple(ClassicalUpdaterParameter* parameter)
{
    return parameter->get_tuple();
}

#endif // _CPP_UTILITY_CLASSICAL_UPDATER_PARAMETER_H_

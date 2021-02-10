#ifndef _CPP_UTILITY_TRANSVERSE_FIELD_UPDATER_PARAMETER_H_
#define _CPP_UTILITY_TRANSVERSE_FIELD_UPDATER_PARAMETER_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <utility/schedule_list.hpp>

using namespace openjij;
using namespace openjij::utility;

DLLEXPORT TransverseFieldUpdaterParameter* utility_TransverseFieldUpdaterParameter_new(const double beta, const double s)
{
    return new TransverseFieldUpdaterParameter(beta, a);
}

DLLEXPORT void utility_TransverseFieldUpdaterParameter_delete(TransverseFieldUpdaterParameter* parameter)
{
    delete parameter;
}

DLLEXPORT void utility_TransverseFieldUpdaterParameter_get_tuple(TransverseFieldUpdaterParameter* parameter,
                                                                 double* item1,
                                                                 double* item2)
{
    const auto& tuple = parameter->get_tuple();
    *item1 = std::get<0>(tuple);
    *item2 = std::get<1>(tuple);
}

#endif // _CPP_UTILITY_TRANSVERSE_FIELD_UPDATER_PARAMETER_H_

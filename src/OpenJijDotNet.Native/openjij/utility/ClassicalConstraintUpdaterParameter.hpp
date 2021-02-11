#ifndef _CPP_UTILITY_CLASSICAL_CONSTRAINT_UPDATER_PARAMETER_H_
#define _CPP_UTILITY_CLASSICAL_CONSTRAINT_UPDATER_PARAMETER_H_

#include "../export.hpp"
#include "../shared.hpp"

#include <utility/schedule_list.hpp>

using namespace openjij;
using namespace openjij::utility;

DLLEXPORT ClassicalConstraintUpdaterParameter* utility_ClassicalConstraintUpdaterParameter_new(const double beta, const double lambda)
{
    return new ClassicalConstraintUpdaterParameter(beta, lambda);
}

DLLEXPORT void utility_ClassicalConstraintUpdaterParameter_delete(ClassicalConstraintUpdaterParameter* parameter)
{
    delete parameter;
}

DLLEXPORT void utility_ClassicalConstraintUpdaterParameter_get_tuple(ClassicalConstraintUpdaterParameter* parameter,
                                                                     double* item1,
                                                                     double* item2)
{
    const auto& tuple = parameter->get_tuple();
    *item1 = std::get<0>(tuple);
    *item2 = std::get<1>(tuple);
}

#endif // _CPP_UTILITY_CLASSICAL_CONSTRAINT_UPDATER_PARAMETER_H_

#ifndef _CPP_UTILITY_SCHEDULE_LIST_H_
#define _CPP_UTILITY_SCHEDULE_LIST_H_

#include "../export.hpp"
#include "../shared.hpp"
#include <random>

#include <utility/schedule_list.hpp>

using namespace openjij;
using namespace openjij::utility;

DLLEXPORT ClassicalScheduleList* utility_schedule_list_make_classical_schedule_list(const double beta_min,
                                                                                    const double beta_max,
                                                                                    const std::size_t one_mc_step,
                                                                                    const std::size_t num_call_updater)
{
    auto ret = make_classical_schedule_list(beta_min, beta_max, one_mc_step, num_call_updater);
    return new ClassicalScheduleList(ret);
}

DLLEXPORT void utility_schedule_list_ClassicalScheduleList_delete(ClassicalScheduleList* list)
{
    delete list;
}

DLLEXPORT TransverseFieldScheduleList* utility_schedule_list_make_transverse_field_schedule_list(const double beta,
                                                                                                 const std::size_t one_mc_step,
                                                                                                 const std::size_t num_call_updater)
{
    auto ret = make_transverse_field_schedule_list(beta, one_mc_step, num_call_updater);
    return new TransverseFieldScheduleList(ret);
}

DLLEXPORT void utility_schedule_list_TransverseFieldScheduleList_delete(TransverseFieldScheduleList* list)
{
    delete list;
}

#endif // _CPP_UTILITY_SCHEDULE_LIST_H_

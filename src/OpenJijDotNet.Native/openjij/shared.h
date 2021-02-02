#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

enum struct float_type : int32_t
{
    Flaot = 0,
    Double,
};

enum struct graph_type : int32_t
{
    Dense = 0,
    Sparse,
};

enum struct ising_type : int32_t
{
    Classical = 0,
    ContinuousTime,
    Transverse
};

enum struct schedule_list_type : int32_t
{
    Classical = 0,
    Transverse
};


#define ERR_OK                                                            0x00000000

#endif